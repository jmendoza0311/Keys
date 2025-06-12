(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            var logo = document.getElementsByClassName('link');
            logo[0].href = "https://www.visionamos.com/";
            logo[0].target = "_blank";
            logo[0].innerHTML = '<img height="80" src="../SwaggerCustom/Images/logoVisionamos.png" alt="Red Coopcentral">';
            document.getElementsByClassName('select-label')[0].children[0].innerHTML = "Seleccione una versión";
        }, 10);
    });
})();