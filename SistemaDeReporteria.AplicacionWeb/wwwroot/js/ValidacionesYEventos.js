const agregarEventoToggle = (variables) => {
    variables.forEach((variable) => {
        const ck = document.getElementById(`ck_${variable}`);
        
        ck.addEventListener('change', () => {
            if (ck.id != "ck_edad") {
                const contenedor = document.getElementById(`contenedor_${variable}`);
                contenedor.classList.toggle("show");
                const input = contenedor.querySelector('input');
                input.required ? input.required = false : input.required = true;
            } else {
                const edadDesdeContenedor = document.getElementById("contenedor_edad-minima");
                const edadHastaContenedor = document.getElementById("contenedor_edad-maxima");
                const edadDesde = document.getElementById('Edad_Minima');
                const edadHasta = document.getElementById('Edad_Maxima');
                edadDesdeContenedor.classList.toggle("show");
                edadHastaContenedor.classList.toggle("show");
                edadDesde.required ? edadDesde.required = false : edadDesde.required = true;
                edadHasta.required ? edadHasta.required = false : edadHasta.required = true;
            }
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

const obtenerPatronYMensajeError = (nombreInput) => {
    let lista = [];

    switch (nombreInput) {
        case 'Grado_Academico':
        case 'Estado':
        case 'Tipo':
        case 'Area_Cientifica':
        case 'Objetivo_Socioeconomico':
        case 'Eje_De_Planes':
        case 'Unidad_De_Investigacion':
        case 'Canton':
        case 'Region':
        case 'Objetivo_De_Desarrollo_Sostenible':
        case 'Nombre_Del_Investigador':
        case 'Sexo':
            nombreInput = nombreInput.replace('_', ' ');
            lista.push(/[a-zA-Z]/);
            lista.push(`En ${nombreInput} ingrese solamente caracteres`);
            break;
        case 'Fecha_Inicio_Estimada':
        case 'Fecha_Inicio_Real':
        case 'Fecha_Finalizacion_Estimada':
        case 'Fecha_Finalizacion_Real':
        case 'Fecha_De_Inicio':
            nombreInput = nombreInput.replace('_', ' ');
            lista.push(/^\d{2}-\d{2}-\d{4}$|^\d{4}$/);
            lista.push(`En ${nombreInput} debe seguir un formato de fecha dia-mes-año o solamente año`);
            break;
        case 'Edad_Desde':
        case 'Edad_Hasta':
            nombreInput = nombreInput.replace('_', ' ');
            lista.push(/^[0-9]+$/);
            lista.push(`En ${nombreInput} ingrese solamente numeros`);
            break;
        default: throw new Error(`El nombre de la entrada de formulario '${nombreInput}' no es válido`);
    }

    return lista;
}

const validarFormulario = () => {
    const form = document.querySelector('form');

    form.addEventListener('submit', (event) => {
        event.preventDefault();

        const inputs = form.querySelectorAll('input[required]');
        const errores = [];
        
        inputs.forEach((input) => {
           
           const patronYMensaje = obtenerPatronYMensajeError(input.name);
            
                [patron, mensaje] = patronYMensaje;
                const contenido = input.value.trim();

                if (contenido === '') {
                    errores.push(`El campo ${input.name} es obligatorio.`);
                }

                if (!patron.test(contenido)) {
                    errores.push(mensaje);
                }
        });

        if (errores.length > 0) {
            mostrarVentanaModal('Error', errores);
        } else {
            form.submit();
        }
    });
}

const mostrarVentanaModal = (nombreTitulo, errores) => {
    const ventanaModal = document.getElementById('ventanaModal');
    console.log(ventanaModal);
    const titulo = ventanaModal.querySelector('.modal-titulo');
    const contenido = ventanaModal.querySelector('.modal-cuerpo-contenido');
    titulo.textContent = nombreTitulo;
    contenido.textContent = errores.join('\n');
    ventanaModal.style.display = 'block';
}

const ocultarVentanaModal = () => {
    const ventanaModal = document.getElementById('ventanaModal');
    const botonCerrar = ventanaModal.querySelector('.modal-boton');
    const botonDeCierreX = ventanaModal.querySelector('.modal-cerrar');

    const cerrarVentana = () => {
        ventanaModal.style.display = 'none';
    }

    botonDeCierreX.addEventListener('click', cerrarVentana )
    botonCerrar.addEventListener('click', cerrarVentana );
}