(
    function (publicMethod, $) {
        // #region Upload Files For Encryption

        publicMethod.loadUploadFilesPartialView = function () {
            homeController.ShowLoadingIndicator();
            $('#loadUploadFilesPartialView').load(loadUploadFilesPartialViewActionUrl);
        }

        publicMethod.closeUploadFilesPartialView = function () {
            $('#modalUploadFilesToEncrypt').modal('hide');
            $('#modalUploadFilesToEncrypt').remove();
        }

        publicMethod.uploadFilesOnSuccess = function (data, status, xhr) {
            fileCryptController.closeUploadFilesPartialView();
            if (typeof data.Status === "undefined") {
            }
            else if (data.Status === "Success") {
                swalWithBootstrapButtons.fire({
                    title: data.GetGoodJobVerb,
                    text: data.Message,
                    type: 'success',
                    allowOutsideClick: false,
                    showCancelButton: false,
                    confirmButtonText: '<i class="fas fa-check"></i> Ok'
                });
            }
            else if (data.Status === "Error") {
                homeController.showErrorMessagePopUp(data.Message, xhr.getResponseHeader('RequestId'));
            }
            homeController.HideLoadingIndicator();
            
        }

        publicMethod.uploadFilesOnfailure = function (xMLHttpRequest, textStatus, errorThrown) {
            homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
        }

        publicMethod.uploadFilesOnBegin = function (xhr, data) {
            homeController.ShowLoadingIndicator();
        }

        publicMethod.uploadFilesOnComplete = function (xhr, data) {
        }

        // #endregion

        // #region Decrypt And Download Files

        publicMethod.decryptAndDownloadFile = function (fileName, actionUrl) {
            homeController.ShowLoadingIndicator();
            $.ajax({
                url: actionUrl,
                success: function (data, status, xhr) {
                    var blob = new Blob([data]);
                    var link = document.createElement('a');
                    link.href = window.URL.createObjectURL(blob);
                    link.download = fileName;
                    link.click();
                    homeController.HideLoadingIndicator();
                },
                error: function (xMLHttpRequest, textStatus, errorThrown) {
                    homeController.HideLoadingIndicator();
                    homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
                }
            });
        }

        publicMethod.deleteEncryptedFile = function (fileName, actionUrl) {
            homeController.ShowLoadingIndicator();
            $.ajax({
                url: actionUrl,
                success: function (data, status, xhr) {                   
                    homeController.HideLoadingIndicator();

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
                error: function (xMLHttpRequest, textStatus, errorThrown) {
                    homeController.HideLoadingIndicator();
                    homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
                }
            });
        }
        // #endregion
    }(window.fileCryptController = window.fileCryptController || {}, jQuery)
);  