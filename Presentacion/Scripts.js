function validarApellido() {
    const txtApellido = document.getElementById("txtApellido");
    if (txtApellido.value == "") {
        txtApellido.classList.add("is-invalid");
        txtApellido.classList.remove("is-valid");
        return false;
    }
    txtApellido.classList.remove("is-invalid");
    txtApellido.classList.add("is-valid");
    return true;
}

function validarNombre() {
    const txtNombre = document.getElementById("txtNombre");
    if (txtNombre.value == "") {
        txtNombre.classList.add("is-invalid");
        txtNombre.classList.remove("is-valid");
        return false;
    }
    txtNombre.classList.remove("is-invalid");
    txtNombre.classList.add("is-valid");
    return true;
}