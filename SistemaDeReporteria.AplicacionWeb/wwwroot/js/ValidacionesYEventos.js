const agregarEventoToggle = (variables) => {
    variables.forEach((variable) => {
        const ck = document.getElementById(`ck_${variable}`);
    
        ck.addEventListener('change', () => {
            if (ck.id !== "ck_edad") {
                const contenedor = document.getElementById(`contenedor_${variable}`);
                contenedor.classList.toggle("show");
                const input = contenedor.querySelector('input');
                if (input !== null) {
                    input.required ? input.required = false : input.required = true;
                } else {
                    const select = contenedor.querySelector('select');
                    if (select !== null) {
                        select.required ? select.required = false : select.required = true;
                    }
                }

                if (!contenedor.classList.contains("show")) {
                    var entradas = contenedor.querySelectorAll('input, select');
                    for (var i = 0; i < entradas.length; i++) {
                        var entrada = entradas[i];
                        if (entrada.tagName === 'INPUT') {
                            entrada.value = '';
                        } else if (entrada.tagName === 'SELECT') {
                            entrada.selectedIndex = 0;
                        }
                    }
                }
            } else {
                const edadDesdeContenedor = document.getElementById("contenedor_edad-minima");
                const edadHastaContenedor = document.getElementById("contenedor_edad-maxima");
                const edadDesde = document.getElementById('VariablesInvestigador_Edad_Minima') || document.getElementById('VariablesInvestigadorXProyecto_Edad_Minima');
                const edadHasta = document.getElementById('VariablesInvestigador_Edad_Maxima') || document.getElementById('VariablesInvestigadorXProyecto_Edad_Maxima');
                edadDesdeContenedor.classList.toggle("show");
                edadHastaContenedor.classList.toggle("show");
                edadDesde.required ? edadDesde.required = false : edadDesde.required = true;
                edadHasta.required ? edadHasta.required = false : edadHasta.required = true;

                if (!edadDesdeContenedor.classList.contains("show")) {
                    edadDesde.value = '';
                    edadHasta.value = '';
                }
            }
        });
    });
}

const cambiarEstadoBtnSubmit = () => {
    const checkboxes = document.querySelectorAll('input[type="checkbox"]');
    const submitBtn = document.getElementById('btnSubmit');

    checkboxes.forEach(checkbox => {
        checkbox.addEventListener('change', () => {
            const alMenosUnoSeleccionado = Array.from(checkboxes).some(checkbox => checkbox.checked);
            submitBtn.disabled = !alMenosUnoSeleccionado;
        });
    });
};

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

const mostrarVentanaModal = (nombreTitulo, errores) => {
    const ventanaModal = document.getElementById('ventanaModal');
    console.log(ventanaModal);
    const titulo = ventanaModal.querySelector('.modal-titulo');
    const contenido = ventanaModal.querySelector('.modal-cuerpo-contenido');
    titulo.textContent = nombreTitulo;
    contenido.innerHTML = errores.join('<br>');
    ventanaModal.style.display = 'block';
}

const ocultarVentanaModal = () => {
    const ventanaModal = document.getElementById('ventanaModal');
    const botonCerrar = ventanaModal.querySelector('.modal-boton');

    const cerrarVentana = () => {
        ventanaModal.style.display = 'none';
    }

    botonCerrar.addEventListener('click', cerrarVentana );
}