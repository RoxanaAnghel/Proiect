(function () {

    "use strict";

    angular
        .module("getAPet")
        .controller("UploadsController", UploadsController);

    UploadsController.$inject = ['$window', 'uploadsService', 'Upload'];


    function UploadsController($window, fileService, Upload) {

        var apiUrl = '/api/uploads';

        var vm = this;

        //Variables
        vm.photos = [];
        vm.files = [];
        vm.previewPhoto = {};
        vm.spinner = {
            active: true
        };

        //Functions
        function setPreviewPhoto(photo) {
            vm.previewPhoto = photo;
        }

        function activate() {
            vm.spinner.active = true;
            fileService.getAll()
              .then(function (data) {
                  vm.photos = data.Photos;
                  vm.spinner.active = false;
                  setPreviewPhoto();
              }, function (err) {
                  console.log("Error status: " + err.status);
                  vm.spinner.active = false;
              });
        }

        function uploadFiles(files) {
            vm.spinner.active = true;
            Upload.upload({
                url: apiUrl,
                data: { file: files }
            })
            .then(function (response) {
                activate();
                setPreviewPhoto();
                vm.spinner.active = false;
            }, function (err) {
                console.log("Error status: " + err.status);
                vm.spinner.active = false;
            });
        }

        function removePhoto(photo) {
            fileService.deletePhoto(photo.Name)
              .then(function () {
                  activate();

                  setPreviewPhoto();
              });
        }

        //Set scope 
        activate();

        vm.uploadFiles = uploadFiles;
        vm.remove = removePhoto;
        vm.setPreviewPhoto = setPreviewPhoto;
    };
})();