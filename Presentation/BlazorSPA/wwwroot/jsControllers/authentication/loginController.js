(
    function (publicMethod, $) {
        $('#Password').attr('type', 'password');

        publicMethod.registerPageOnLoad = function () {
        }

        publicMethod.onUserLoginSuccess = function (userName, url) {
            let timerInterval
            Swal.fire({
                title: 'Congratulation!',
                html: '  <blockquote class="blockquote pt-2"> <p> You have ' +

                    ' loggeed in successfully.<br> <br><small class="text-muted"> Redirecting to Home screen in <strong></strong> seconds.'
                    + '</small></p></blockquote> ',
                timer: 3000,
                allowOutsideClick: false,
                onBeforeOpen: () => {
                    Swal.showLoading()
                    timerInterval = setInterval(() => {
                        Swal.getContent().querySelector('strong')
                            .textContent = Swal.getTimerLeft()
                    }, 100)
                },
                onClose: () => {
                    homeController.RedirectToUrl(url);

                    clearInterval(timerInterval)
                }
            }).then((result) => {
                if (
                    // Read more about handling dismissals
                    result.dismiss === Swal.DismissReason.timer
                ) {
                    console.log('I was closed by the timer')
                }
            });
        }
    }(window.registerController = window.registerController || {}, jQuery)
);