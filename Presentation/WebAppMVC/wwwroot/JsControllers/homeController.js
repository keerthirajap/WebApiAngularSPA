(
    function (publicMethod, $) {
        publicMethod.showAjaxErrorMessagePopUp = function (xMLHttpRequest, textStatus, errorThrown) {
            swalWithBootstrapButtons.fire({
                title: 'Oops...',
               
                type: 'error',
                html: '<br> <br>  An error occurred while processing your request. <br> <br> <br> ' +
                    '<div style="text-align: center; font-size : 14px;" >   Error Message: ' + XMLHttpRequest.status + " " + errorThrown +
                    '<br> <br> ' + ' Request Id : ' + xMLHttpRequest.getResponseHeader('RequestId') + ' </div>',
                showCancelButton: true,
                showConfirmButton: false,
                allowOutsideClick: false,
                cancelButtonText: '<i class="fas fa-times"></i> Cancel'
            });
        }

        publicMethod.showErrorMessagePopUp = function (message, requestId) {
            swalWithBootstrapButtons.fire({
                title: 'Oops...',
                text: message,
                type: 'error',
                html: '<br> <br> ' +
                    '<div style="text-align: center; font-size : 16px;" >   Error Message: ' + message +
                    '<br> <br> ' + ' Request Id : ' + requestId + ' </div>',
                showCancelButton: true,
                showConfirmButton: false,
                allowOutsideClick: false,
                cancelButtonText: '<i class="fas fa-times"></i> Close'
            });
        },
            publicMethod.onLogoutButtonClick = function (url) {
                $.ajax({
                    async: true,
                    type: "GET",
                    url: url,
                    contentType: 'application/json;',
                    dataType: 'json',
                    begin: function () {
                    },
                    complete: function () {
                    },
                    success: function (data) {
                        swalWithBootstrapButtons.fire({
                            text: data.Message,
                            type: 'success',
                            showCancelButton: false,
                            showConfirmButton: false,
                            allowOutsideClick: false,
                        });

                        setTimeout(
                            function () {
                                location.reload();
                            }, 1000);
                    },
                    error: function (xMLHttpRequest, textStatus, errorThrown) {
                        homeController.showAjaxErrorMessagePopUp(xMLHttpRequest, textStatus, errorThrown);
                    }
                });
            },

            publicMethod.getCookie = function (cname) {
                var name = cname + "=";
                var decodedCookie = decodeURIComponent(document.cookie);
                var ca = decodedCookie.split(';');
                for (var i = 0; i < ca.length; i++) {
                    var c = ca[i];
                    while (c.charAt(0) == ' ') {
                        c = c.substring(1);
                    }
                    if (c.indexOf(name) == 0) {
                        return c.substring(name.length, c.length);
                    }
                }
                return "";
            },

            publicMethod.getSignarRConnectionId = function () {
                return $('#signalRconnectionId').val();
            },

            publicMethod.ShowLoaddingIndicator = function () {
                document.getElementById("myNav").style.height = "100%";
            },

            publicMethod.HideLoaddingIndicator = function () {
                setTimeout(
                    function () {
                        document.getElementById("myNav").style.height = "0%";
                    }, 500);
            },

            publicMethod.RedirectToHomePage = function () {
                // JsMain.ShowLoaddingIndicator();
                var url = "\Home";
                window.location.href = url;
            },

            publicMethod.RedirectToUrl = function (url) {
                // JsMain.ShowLoaddingIndicator();

                window.location.href = url;
            },

            publicMethod.reloadCurrentPage = function () {
                location.reload();
            },

            publicMethod.ShowMessageShowReloadPopUp = function (header, message) {
                $('#modalMessageShowReloadPopUpHeaderTitle').text(header);
                $('#modalMessageShowReloadPopUpMessage').text(message);
                $('#modalMessageShowReloadPopUp').modal('show');
            },

            publicMethod.ShowMessageShowPopUp = function (header, message) {
                $('#modalMessageShowPopUpHeaderTitle').text(header);
                $('#modalMessageShowPopUpMessage').text(message);
                $('#modalMessageShowPopUp').modal('show');
            },

            publicMethod.ShowMessageShowPopUp1 = function (data) {
                var splitedDtata = data.split("|");
                if (splitedDtata[1]) {
                    $('#modalMessageShowPopUpHeaderTitle').text(splitedDtata[2]);
                    $('#modalMessageShowPopUpMessage').text(splitedDtata[3]);
                    $('#modalMessageShowPopUp').modal('show');
                }
            }
    }(window.homeController = window.homeController || {}, jQuery)
);