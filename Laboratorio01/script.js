
  function validarFormulario() {
    var errorMessages = '';
    
    // Formulario 1: Datos Generales
    var nombre = document.getElementById('nombre').value;
    var fechaNacimiento = document.getElementById('fechaNacimiento').value;
    var direccion = document.getElementById('direccion').value;
    var telefono = document.getElementById('telefono').value;
    var sexoM = document.getElementById('sexoM');
    var sexoF = document.getElementById('sexoF');

    // Validar que los campos no estén vacíos
    if (nombre.trim() === '') {
      errorMessages += '<p>El campo Nombre es obligatorio.</p>';
    }

    if (fechaNacimiento.trim() === '') {
      errorMessages += '<p>El campo Fecha de Nacimiento es obligatorio.</p>';
    }

    if (direccion.trim() === '') {
      errorMessages += '<p>El campo Dirección es obligatorio.</p>';
    }

    if (telefono.trim() === '') {
      errorMessages += '<p>El campo Teléfono es obligatorio.</p>';
    }

    // Validar que se seleccione al menos una opción de Sexo
    if (!sexoM.checked && !sexoF.checked) {
      errorMessages += '<p>Por favor, seleccione su Sexo.</p>';
    }

    // Formulario 2: Pago con Tarjeta
    var numeroTarjeta = document.getElementById('numeroTarjeta').value;
    var nombreTarjeta = document.getElementById('nombreTarjeta').value;
    var fechaExpiracion = document.getElementById('fechaExpiracion').value;
    var cvv = document.getElementById('cvv').value;

    // Validar que los campos no estén vacíos
    if (numeroTarjeta.trim() === '') {
      errorMessages += '<p>El campo Número de Tarjeta es obligatorio.</p>';
    }

    if (nombreTarjeta.trim() === '') {
      errorMessages += '<p>El campo Nombre en la Tarjeta es obligatorio.</p>';
    }

    if (fechaExpiracion.trim() === '') {
      errorMessages += '<p>El campo Fecha de Expiración es obligatorio.</p>';
    } else {
      // Validar formato de Fecha de Expiración (MM/AA)
      var regexFechaExpiracion = /^(0[1-9]|1[0-2])\/\d{2}$/;
      if (!regexFechaExpiracion.test(fechaExpiracion)) {
        errorMessages += '<p>El formato de Fecha de Expiración debe ser MM/AA.</p>';
      }
    }

    if (cvv.trim() === '') {
      errorMessages += '<p>El campo CVV es obligatorio.</p>';
    } else {
      // Validar que el CVV sea un número de 3 o 4 dígitos
      var regexCVV = /^\d{3,4}$/;
      if (!regexCVV.test(cvv)) {
        errorMessages += '<p>El CVV debe ser un número de 3 o 4 dígitos.</p>';
      }
    }

    var errorDiv = document.getElementById('errorMessages');
    errorDiv.innerHTML = errorMessages;
      
    // Retornar true para enviar el formulario o false para detener el envío
    return errorMessages === '';
  }
