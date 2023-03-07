const agregarEventoToggle = (variables) => {
    variables.forEach((variable) => {
        const ck = document.getElementById(`ck_${variable}`);
        const contenedor = document.getElementById(`contenedor_${variable}`);
        ck.addEventListener('change', () => {
            contenedor.classList.toggle("show");
        })
    });
}

const validarCantidadCheckboxActivos = () => {
    let checkboxes = document.querySelectorAll('.contenedor-check-variable input[type="checkbox"]');
    let cantidadCheckboxesActivos = 0;
    const MAX_CANTIDAD_CHECKBOX = 4;

    for (var i = 0; i < checkboxes.length; i++) {
        checkboxes[i].addEventListener('click', function () {
            if (this.checked) {
                cantidadCheckboxesActivos++;

                if (cantidadCheckboxesActivos == MAX_CANTIDAD_CHECKBOX) {
                    for (var j = 0; j < checkboxes.length; j++) {
                        if (!checkboxes[j].checked) {
                            checkboxes[j].disabled = true;
                        }
                    }
                }
            } else {
                cantidadCheckboxesActivos--;

                if (cantidadCheckboxesActivos == MAX_CANTIDAD_CHECKBOX - 1) {
                    for (var j = 0; j < checkboxes.length; j++) {
                        if (!checkboxes[j].checked) {
                            checkboxes[j].disabled = false;
                        }
                    }
                }
            }
        });
    }
}