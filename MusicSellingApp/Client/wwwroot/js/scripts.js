redirectToCheckout = function (sessionId) {
    var stripe = Stripe('pk_test_51HakXCLFPzNgSBSANeSzkeuB3Auq48VYiEnswBQRz957pA8rhSnfFnrqVAPQMqI1P8nIh0vkz2KgWHSLuL2Vx2Kn00S38a7TJd');
    stripe.redirectToCheckout({
        sessionId: sessionId
    });
};