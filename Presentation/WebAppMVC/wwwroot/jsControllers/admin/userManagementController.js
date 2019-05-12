(
    function (publicMethod, $) {
        publicMethod.loadAddUserPartialView = function (acionUrl) {
            homeController.ShowLoaddingIndicator();
            $.ajax({
                async: true,
                type: "GET",
                url: acionUrl,
                begin: function () {
                },
                complete: function () {
                },
                success: function (data) {
                    $('#loadAddUserPartialView').html(data);

                    setTimeout(
                        function () {
                            homeController.HideLoaddingIndicator();
                        }, 200);
                },
                error: function (xMLHttpRequest, textStatus, errorThrown) {
                    homeController.HideLoaddingIndicator();
                    homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
                }
            });
        }

        publicMethod.closeAddUserPartialView = function () {
            $('#modalAddUser').modal('hide');
            $('#modalAddUser').remove();
        }

        publicMethod.addUserOnSuccess = function (data, status, xhr) {

            if (typeof data.Status === "undefined") {
                $('#modalAddUser').modal('hide');
                $('#modalAddUser').remove();
                $('#loadAddUserPartialView').empty().html(data);
            }
            else if (data.Status === "Success") {
                $('#modalAddUser').modal('hide');
                $('#modalAddUser').remove();

                swalWithBootstrapButtons.fire({
                    title: data.GetGoodJobVerb,
                    text: data.Message,
                    type: 'success',
                    allowOutsideClick: false,
                    showCancelButton: false,
                    confirmButtonText: '<i class="fas fa-times"></i> Close'
                }).then((result) => {
                    if (result.value) {
                        homeController.reloadCurrentPage();
                    }
                });
            }

            else if (data.Status === "Error") {
                $('#modalAddUser').modal('hide');
                $('#modalAddUser').remove();
                homeController.showErrorMessagePopUp(data.Message ,xhr.getResponseHeader('RequestId'));
            }
        }

        publicMethod.addUserOnfailure = function (xMLHttpRequest, textStatus, errorThrown) {
            homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
        }
        publicMethod.addUserOnBegin = function (xhr, data) {
        }
        publicMethod.addUserOnComplete = function (xhr, data) {
        }
    }(window.userManagementController = window.userManagementController || {}, jQuery)
);