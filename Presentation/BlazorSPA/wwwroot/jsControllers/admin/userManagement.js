(
    function (publicMethod, $) {
        setTimeout(
            function () {
                $("#btnForPageLoaded").trigger("click");
            }, 1000);
    }(window.userManagement = window.userManagement || {}, jQuery)
);