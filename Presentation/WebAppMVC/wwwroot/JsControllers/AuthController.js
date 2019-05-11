(
    function (publicMethod, $) {
        publicMethod.registerUserOnBegin = function () {
        }

        publicMethod.registerUserOnComplete = function () {
        }

        publicMethod.registerUserOnSuccess = function (data, status, xhr) {
            if (jQuery.type(data.Status) === "undefined") {
            }

            else {
                swalWithBootstrapButtons.fire({
                    title: data.GetGoodJobVerb,
                    text: data.Message,
                    type: 'success',
                    showCancelButton: false,
                    confirmButtonText: '<i class="fas fa-home"></i> Go to Home'
                }).then((result) => {
                    if (result.value) {
                        homeController.RedirectToHomePage();
                    }
                });
            }
        }

        publicMethod.registerUserOnfailure = function () {
        }
    }(window.authController = window.authController || {}, jQuery)
);