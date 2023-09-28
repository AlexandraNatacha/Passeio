/*Configura e anexa a camera*/
Webcam.set({
    width: 400,
    height: 300,
    image_format: 'jpeg',
    jpeg_quality: 90
});
Webcam.attach('#mac_camera');

/*Codigo para tirar a foto e exibir localmente*/
function captura_imagem() {
    // tira a foto e obtem os dados da imagem
    Webcam.snap(function (data_uri) {
        // exibe o resultado na pagina
        document.getElementById('resultado').innerHTML =
            '<img src="' + data_uri + '"/>';
        //Webcam.upload(data_uri, '/Camera/CapturaImagemPost', function (code, text) {
        //    alert('Imagem Capturada');
        //});
        document.getElementById('Imagem').value = data_uri;
    });
}