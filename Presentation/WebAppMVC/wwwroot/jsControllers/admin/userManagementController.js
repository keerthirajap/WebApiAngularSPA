(
    function (publicMethod, $) {
        // #region Add User
        publicMethod.loadAddUserPartialView = function (acionUrl) {
            homeController.ShowLoadingIndicator();
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
                            homeController.HideLoadingIndicator();
                        }, 200);
                },
                error: function (xMLHttpRequest, textStatus, errorThrown) {
                    homeController.HideLoadingIndicator();
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
                    confirmButtonText: '<i class="fas fa-check"></i> Ok'
                }).then((result) => {
                    if (result.value) {
                        homeController.reloadCurrentPage();
                    }
                });
            }

            else if (data.Status === "Error") {
                $('#modalAddUser').modal('hide');
                $('#modalAddUser').remove();
                homeController.showErrorMessagePopUp(data.Message, xhr.getResponseHeader('RequestId'));
            }
        }

        publicMethod.addUserOnfailure = function (xMLHttpRequest, textStatus, errorThrown) {
            homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
        }

        publicMethod.addUserOnBegin = function (xhr, data) {
        }

        publicMethod.addUserOnComplete = function (xhr, data) {
        }

        // #endregion

        // #region Edit User
        publicMethod.loadEditUserPartialView = function (actionUrl) {
            homeController.ShowLoadingIndicator();
            $.ajax({
                async: true,
                type: "GET",
                url: actionUrl,
                begin: function () {
                },
                complete: function () {
                },
                success: function (data) {
                    $('#loadEditUserPartialView').html(data);

                    setTimeout(
                        function () {
                            homeController.HideLoadingIndicator();
                        }, 200);
                },
                error: function (xMLHttpRequest, textStatus, errorThrown) {
                    homeController.HideLoadingIndicator();
                    homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
                }
            });
        }

        publicMethod.closeEditUserPartialView = function () {
            $('#modalEditUser').modal('hide');
            $('#modalEditUser').remove();
        }

        publicMethod.editUserOnBegin = function (xhr, data) {
            homeController.ShowLoadingIndicator();
        }

        publicMethod.editUserOnSuccess = function (data, status, xhr) {
            homeController.HideLoadingIndicator();
            if (typeof data.Status === "undefined") {
                $('#modalEditUser').modal('hide');
                $('#modamodalEditUserlAddUser').remove();
                $('#loadEditUserPartialView').empty().html(data);
            }
            else if (data.Status === "Success") {
                $('#modalEditUser').modal('hide');
                $('#modalEditUser').remove();

                swalWithBootstrapButtons.fire({
                    title: data.GetGoodJobVerb,
                    text: data.Message,
                    type: 'success',
                    allowOutsideClick: false,
                    showCancelButton: false,
                    confirmButtonText: '<i class="fas fa-check"></i> Ok'
                }).then((result) => {
                    if (result.value) {
                        homeController.reloadCurrentPage();
                    }
                });
            }

            else if (data.Status === "Error") {
                $('#modalEditUser').modal('hide');
                $('#modalEditUser').remove();
                homeController.showErrorMessagePopUp(data.Message, xhr.getResponseHeader('RequestId'));
            }
        }

        publicMethod.editUserOnComplete = function (xhr, data) {
        }

        publicMethod.editUserOnfailure = function (xMLHttpRequest, textStatus, errorThrown) {
            homeController.HideLoadingIndicator();
            homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
        }

        // #endregion

        // #region Delete User

        publicMethod.loadDeleteUserPartialView = function (actionUrl) {
            homeController.ShowLoadingIndicator();
            $.ajax({
                async: true,
                type: "GET",
                url: actionUrl,
                begin: function () {
                },
                complete: function () {
                },
                success: function (data) {
                    //alert(data);
                    //$('#loadDeleteUserPartialView').empty().html(data);
                    $('#loadEditUserPartialView').append(data);
                    setTimeout(
                        function () {
                            homeController.HideLoadingIndicator();
                        }, 200);
                },
                error: function (xMLHttpRequest, textStatus, errorThrown) {
                    homeController.HideLoadingIndicator();
                    homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
                }
            });
        }

        publicMethod.closeDeleteUserPartialView = function () {
            $('#modalDeleteUser').modal('hide');
            $('#modalDeleteUser').remove();
        }

        publicMethod.deleteUserOnBegin = function (xhr, data) {
            homeController.ShowLoadingIndicator();
        }

        publicMethod.deleteUserOnSuccess = function (data, status, xhr) {
            homeController.HideLoadingIndicator();
            if (typeof data.Status === "undefined") {
                $('#modalDeleteUser').modal('hide');
            }
            else if (data.Status === "Success") {
                $('#modalDeleteUser').modal('hide');
                $('#modalDeleteUser').remove();

                swalWithBootstrapButtons.fire({
                    title: data.GetGoodJobVerb,
                    text: data.Message,
                    type: 'success',
                    allowOutsideClick: false,
                    showCancelButton: false,
                    confirmButtonText: '<i class="fas fa-check"></i> Ok'
                }).then((result) => {
                    if (result.value) {
                        homeController.reloadCurrentPage();
                    }
                });
            }

            else if (data.Status === "Error") {
                $('#modalDeleteUser').modal('hide');
                $('#modalDeleteUser').remove();
                homeController.showErrorMessagePopUp(data.Message, xhr.getResponseHeader('RequestId'));
            }
        }

        publicMethod.deleteUserOnComplete = function (xhr, data) {
        }

        publicMethod.deleteUserOnfailure = function (xMLHttpRequest, textStatus, errorThrown) {
            homeController.HideLoadingIndicator();
            homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
        }

        // #endregion
    }(window.userManagementController = window.userManagementController || {}, jQuery)
);