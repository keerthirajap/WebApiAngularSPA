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

        }

        publicMethod.uploadFilesOnfailure = function (xMLHttpRequest, textStatus, errorThrown) {
            homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
        }

        publicMethod.uploadFilesOnBegin = function (xhr, data) {
        }

        publicMethod.uploadFilesOnComplete = function (xhr, data) {
        }

        // #endregion


        // #region Decrypt And Download Files

        publicMethod.decryptAndDownloadFile = function (url) {
            
            location = url;
        }

        // #endregion

    }(window.fileCryptController = window.fileCryptController || {}, jQuery)
);  