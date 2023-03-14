const agregarEventoToggle = (variables) => {
    variables.forEach((variable) => {
        const ck = document.getElementById(`ck_${variable}`);
        const contenedor = document.getElementById(`contenedor_${variable}`);
        ck.addEventListener('change', () => {
            contenedor.classList.toggle("show");
            const input = contenedor.querySelector('input');
            input.required ? input.required = false : input.required = true;
        })
    });
}

const validarCantidadCheckboxActivos = () => {
    const checkboxes = document.querySelectorAll('.contenedor-check-variable input[type="checkbox"]');
    let cantidadCheckboxesActivos = 0;
    const MAX_CANTIDAD_CHECKBOX = 4;

    checkboxes.forEach((checkbox) => {
        checkbox.addEventListener('click', function () {
            if (this.checked) {
                cantidadCheckboxesActivos++;

                if (cantidadCheckboxesActivos == MAX_CANTIDAD_CHECKBOX) {
                    checkboxes.forEach((checkbox) => {
                        if (!checkbox.checked) {
                            checkbox.disabled = true;
                        }
                    });
                }
            } else {
                cantidadCheckboxesActivos--;

                if (cantidadCheckboxesActivos == MAX_CANTIDAD_CHECKBOX - 1) {
                    checkboxes.forEach((checkbox) => {
                        if (!checkbox.checked) {
                            checkbox.disabled = false;
                        }
                    });
                }
            }
        });
    });
}

const validarCamposFormulario = () => {
    const inputs = document.querySelectorAll('form div div input');
    inputs.forEach((input) => {
        try {
            const patronYMensaje = obtenerPatronYMensajeError(input.name);
            [patron, mensaje] = patronYMensaje;
            input.pattern = patron;
            input.title = mensaje;
        } catch (err) {
        }
    });
}

const obtenerPatronYMensajeError = (nombreInput) => {
    const lista = [];

    switch (nombreInput) {
        case 'Grado_Academico':
            lista.push('a-zA-Z');
            lista.push('Ingrese solamente caracteres');
            break;
        default: lista = null;
    }

    return lista;
}