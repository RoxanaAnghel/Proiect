using Pet.Database;
using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pet.Services.Conversations
{
    public class ConversationService : IConversationService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ConversationService(UnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public Conversation[] GetAllForPet(Guid petId, Guid ownerId)
        {
            Conversation[] conversations = GetAllForUser(ownerId).Where(c => c.PetID == petId).ToArray();
            return conversations;
            
        }

        public Conversation[] GetAllForUser(Guid userId)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                List<Conversation> conversations = new List<Conversation>();

                Database.Entities.Conversation[] dbConversations = unitOfWork.ConversationRepository.GetAllFor(userId);

                Guid[] otherUserIds = dbConversations.SelectMany(x => new Guid[2] { x.FromID, x.PetOwnerId }).Distinct().ToArray();
                Guid[] petIds = dbConversations.Select(x => x.PetID).Distinct().ToArray();

                Database.Entities.UserDetails[] otherUsers = unitOfWork.UserDetailsRepository.GetByIds(otherUserIds);

                Database.Entities.Pet[] pets = unitOfWork.PetRepository.GetByIds(petIds);

                UserDetails yourDetails = otherUsers.First(x => x.ID == userId);

                foreach (Database.Entities.Conversation dbConversation in dbConversations)
                {
                    Guid otherUserId = userId == dbConversation.FromID ? dbConversation.PetOwnerId : dbConversation.FromID;

                    Database.Entities.UserDetails otherUser = otherUsers.First(x => x.ID == otherUserId);
                    Database.Entities.Pet pet = pets.FirstOrDefault(x => x.ID == dbConversation.PetID);

                    if (pet != null)
                    {
                        conversations.Add(new Conversation()
                        {
                            WithID = dbConversation.FromID,
                            WithImagineUrl = otherUser.ImagineUrl, //sender.Image,
                            ID = dbConversation.ID,
                            PetID = dbConversation.PetID,
                            PetImagineUrl = pet.ImageUrl,
                            YourId = userId,
                            YourImagineUrl = yourDetails.ImagineUrl,
                            Active = dbConversation.Status,
                            WithName = otherUser.Name
                        });
                    }
                }

                return conversations.ToArray();
            }
        }

        public Database.Entities.Conversation GetById(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.ConversationRepository.GetByID(id);
            }
        }

        public Conversation GetById_(Guid conversationId,Guid current)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                Database.Entities.Conversation dbConversation= unitOfWork.ConversationRepository.GetByID(conversationId);

                

                Guid otherUserId = current == dbConversation.FromID ? dbConversation.PetOwnerId : dbConversation.FromID;

                Database.Entities.UserDetails otherUser = unitOfWork.UserDetailsRepository.GetByID(otherUserId);
                Database.Entities.Pet pet = unitOfWork.PetRepository.GetByID(dbConversation.PetID);

                Conversation conversation=new Conversation()
                {
                    WithID = dbConversation.FromID,
                    WithImagineUrl = otherUser.ImagineUrl, //sender.Image,
                    ID = dbConversation.ID,
                    PetID = dbConversation.PetID,
                    PetImagineUrl = pet.ImageUrl,
                    YourId = dbConversation.PetOwnerId,
                    YourImagineUrl = dbConversation.PetOwnerImagineUrl,
                    Active = dbConversation.Status
                };

                return conversation;

            }
        }

        public Database.Entities.Conversation GetConversationBeetwen(Guid userId, Guid petId)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                if (!unitOfWork.ConversationRepository.ExistsBetween(userId, petId))
                {
                    Database.Entities.Pet pet = unitOfWork.PetRepository.GetByID(petId);
                    UserDetails petOwner = unitOfWork.UserDetailsRepository.GetByID(pet.OwnerID);
                    UserDetails user = unitOfWork.UserDetailsRepository.GetByID(userId);
                    Database.Entities.Conversation dbConversation = new Database.Entities.Conversation() { ID = Guid.NewGuid(), PetID = petId, PetOwnerId = pet.OwnerID, PetImagineUrl = pet.ImageUrl, FromID = userId };
                    unitOfWork.ConversationRepository.Create(dbConversation);
                    unitOfWork.Save();
                    return dbConversation;
                }
                return unitOfWork.ConversationRepository.GetConversationBetween(userId, petId);
            }
        }
    }
}