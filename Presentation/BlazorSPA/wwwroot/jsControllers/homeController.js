(
    function (publicMethod, $) {
        publicMethod.showAjaxErrorMessagePopUp = function (xMLHttpRequest, textStatus, errorThrown) {
            if (xMLHttpRequest.status == "403") {
                swalWithBootstrapButtons.fire({
                    title: 'Access Denied!',

                    type: 'warning',
                    html: '<br> Your request has been denied due to in-sufficient access. <br> <br>' +
                        '<div style="text-align: center; font-size : 14px;" >   Error Message: ' + xMLHttpRequest.status + " " + errorThrown +
                        '<br> <br> ' + ' Request Id : ' + xMLHttpRequest.getResponseHeader('RequestId') + ' </div>',
                    showCancelButton: true,
                    showConfirmButton: false,
                    allowOutsideClick: false,
                    cancelButtonText: '<i class="fas fa-times"></i> Close'
                });
            }
            else {
                swalWithBootstrapButtons.fire({
                    title: 'Oops...',

                    type: 'error',
                    html: '<br> An error occurred while processing your request. <br> <br>' +
                        '<div style="text-align: center; font-size : 14px;" >   Error Message: ' + xMLHttpRequest.status + " " + errorThrown +
                        '<br> <br> ' + ' Request Id : ' + xMLHttpRequest.getResponseHeader('RequestId') + ' </div>',
                    showCancelButton: true,
                    showConfirmButton: false,
                    allowOutsideClick: false,
                    cancelButtonText: '<i class="fas fa-times"></i> Close'
                });
            }
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

            publicMethod.ShowLoadingIndicator = function () {
            document.getElementById("processingOverlay").style.height = "100%";
            },

            publicMethod.HideLoadingIndicator = function () {
                setTimeout(
                    function () {
                        document.getElementById("processingOverlay").style.height = "0%";
                    }, 500);
            },

            publicMethod.updateProgressBar = function (percentage) {
            var delay = 40;

                $("#progressBar")
                    .attr("aria-valuenow", percentage);

                $("#progressBar")
                    .css("width", percentage + "%")

                $("#progressBar").prop('Counter', percentage).animate({
                    Counter: percentage
                }, {
                        duration: delay,
                        step: function (now) {
                            $(this).text(Math.ceil(now) + '%');
                            $('#progressCompleted').text(Math.ceil(now) + '% Completed');
                        }
                    });

                document.getElementById("progressBarDiv").style.height = "100%";
            },

            publicMethod.showProgressbar = function () {
                $("#progressBar")
                    .attr("aria-valuenow", 0);

                $("#progressBar")
                    .css("width", 0 + "%")

                document.getElementById("progressBarDiv").style.height = "100%";
            },

            publicMethod.hideProgressbar = function () {

            setTimeout(
                function () {
                    $("#progressBar")
                        .attr("aria-valuenow", 0);

                    $("#progressBar")
                        .css("width", 0 + "%")
                }, 1000);

                setTimeout(
                    function () {
                        document.getElementById("progressBarDiv").style.height = "0%";
                    }, 300);

            },

            publicMethod.RedirectToHomePage = function () {
                // JsMain.ShowLoadingIndicator();
                var url = "\Home";
                window.location.href = url;
            },

            publicMethod.RedirectToUrl = function (url) {
                // JsMain.ShowLoadingIndicator();

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

        // #region User Details
        publicMethod.getUserDetails = function (actionUrl) {
            homeController.ShowLoadingIndicator();
            $('#loadUserDetailsPartialView').load(actionUrl);
        }

        publicMethod.closeGetUserDetailsPartialView = function (actionUrl) {
            $('#modalUserDetails').modal('hide');
            $('#modalUserDetails').remove();
        }
        // #endregion
    }(window.homeController = window.homeController || {}, jQuery)
);