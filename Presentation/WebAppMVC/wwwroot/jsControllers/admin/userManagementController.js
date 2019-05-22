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

        publicMethod.saveUserDetailsButtonClick = function () {
            var activeTab = $(".tab-content").find(".active");
            var activeTabId = activeTab.attr('id');
           
            if (activeTabId == "profile") {
                $("#formEditUser").submit();
            }
            else if (activeTabId == "roles") {
                userManagementController.modifyUserRoles(editUserRolesAsyncUrl)
            }
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
                $('#modalEditUser').remove();
                $('#loadEditUserPartialView').empty().html(data);
            }
            else if (data.Status === "Success") {

                var activeTab = $(".tab-content").find(".active");
                var activeTabId = activeTab.attr('id');

                userManagementController.closeEditUserPartialView();
                userManagementController.loadEditUserPartialView(getloadEditUserPartialViewAsyncUrl);

                swalWithBootstrapButtons.fire({
                    title: data.GetGoodJobVerb,
                    text: data.Message,
                    type: 'success',
                    allowOutsideClick: false,
                    showCancelButton: false,
                    confirmButtonText: '<i class="fas fa-check"></i> Ok'
                }).then((result) => {
                    if (result.value) {

                        if (activeTabId == "profile") {
                           $('#tabEditUser a[href="#profile"]').tab('show')
                        }
                        else if (activeTabId == "roles") {
                            $('#tabEditUser a[href="#roles"]').tab('show') 
                        }
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

        // #region Edit User Roles
        publicMethod.loadUpdateUserRolesPartialView = function (actionUrl) {
            $('#modalEditUser').modal('hide');
            $('#modalEditUser').remove();
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
                    $('#loadEditUserPartialView').empty().html(data);

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

        publicMethod.closeEditUserRolesPartialView = function () {
            $('#modalEditUserRoles').modal('hide');
            $('#modalEditUserRoles').remove();
        }

        publicMethod.modifyUserRoles = function (editUserRolesAsyncUrl) {
            homeController.ShowLoadingIndicator();
            var token = $('input[name="__RequestVerificationToken"]').val();
            var roleAssetMappingViewModels = [];

            $('#divUserRolesCards').find('input').each(function () {
                if (this.id != "") {
                    var roleAssetMappingViewModel = {};
                    roleAssetMappingViewModel.IsActive = this.checked;
                    roleAssetMappingViewModel.RoleName = this.id;
                    roleAssetMappingViewModel.RoleId = this.value;
                    roleAssetMappingViewModel.UserId = this.name;
                    roleAssetMappingViewModels.push(roleAssetMappingViewModel);
                }
            });
            $.ajax({
                type: 'POST',
                url: editUserRolesAsyncUrl,
                data: {
                    userRolesBindingModel: roleAssetMappingViewModels,
                    userName: $('#txtUserName').val(),
                    __RequestVerificationToken: token
                },

                success: function (data, status, xhr) {
                    var activeTab = $(".tab-content").find(".active");
                    var activeTabId = activeTab.attr('id');

                    userManagementController.closeEditUserPartialView();
                    userManagementController.loadEditUserPartialView(getloadEditUserPartialViewAsyncUrl);


                    if (jQuery.type(data.Status) === "undefined") {
                    }
                    else if (data.Status == 'ValidatationError') {
                        swalWithBootstrapButtons.fire({
                            title: 'Validatation Error',
                            text: data.Message,
                            type: 'warning',
                            showCancelButton: false,
                            confirmButtonText: '<i class="fas fa-check"></i> Ok'
                        });
                    }
                    else {
                        homeController.HideLoadingIndicator();

                        setTimeout(
                            function () {
                                if (activeTabId == "profile") {
                                    $('#tabEditUser a[href="#profile"]').tab('show')
                                }
                                else if (activeTabId == "roles") {
                                    $('#tabEditUser a[href="#roles"]').tab('show')
                                }
                            }, 500);

                        swalWithBootstrapButtons.fire({
                            title: data.GetGoodJobVerb,
                            text: data.Message,
                            type: 'success',
                            showCancelButton: false,
                            confirmButtonText: '<i class="fas fa-check"></i> Ok'
                        }).then((result) => {
                            if (result.value) {
                              
                            }
                        });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        }

        publicMethod.editUserRolesOnBegin = function (xhr, data) {
            homeController.ShowLoadingIndicator();
        }

        publicMethod.editUserRolesOnSuccess = function (data, status, xhr) {
            homeController.HideLoadingIndicator();
            if (typeof data.Status === "undefined") {
                $('#modalEditUserRoles').modal('hide');
                $('#modalEditUserRoles').remove();
            }
            else if (data.Status === "Success") {
            }
            else if (data.Status === "Error") {
                $('#modalEditUserRoles').modal('hide');
                $('#modalEditUserRoles').remove();
                homeController.showErrorMessagePopUp(data.Message, xhr.getResponseHeader('RequestId'));
            }
        }

        publicMethod.editUserRolesOnComplete = function (xhr, data) {
        }

        publicMethod.editUserRolesOnFailure = function (xMLHttpRequest, textStatus, errorThrown) {
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