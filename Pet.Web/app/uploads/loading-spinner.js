(function (window) {

    "use strict";

    angular
        .module("getAPet")
        .directive("loadingSpinner", overlaySpinner);

    overlaySpinner.$inject = ["$animate"];

    function overlaySpinner($animate) {
        return {
            templateUrl: "/app/uploads/loading-spinner.html",
            scope: { active: "=" },
            transclude: true,
            restrict: "E",
            link: link
        };

        function link(scope, element) {

            scope.$watch("active", statusWatcher);

            function statusWatcher(active) {
                $animate[active ? "addClass" : "removeClass"](element, "loading-spinner-active");
            }
        }
    }
}());