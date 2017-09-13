<template>
	<div class="modal-content">
		<div class="modal-header">
			<button type="button" class="close" data-dismiss="modal" v-on:click="buttonCancelar">Cerrar &times;</button>
			<div id ="btnUpDel">
				<button :disabled="this.isEditable" id="enableEditButton" class="btn btn-primary" v-on:click="buttonEnableEdit"><span class="glyphicon glyphicon-pencil"></span> Modificar</button>
				<button  id="borrarButton" :disabled="this.computeDeleteButton" class="btn btn-danger" v-on:click="buttonBorrar"><span class="glyphicon glyphicon-trash"></span>Borrar</button>
			</div>
		</div>
		<div class="modal-body">
			<div id="Detail" class="detail-div">
				<div id ="FormularioCromos" class="mx-auto">
					<div id="alineacion">
						

						<div class="form-group">

							<label for="Nombre">Título de la colección:</label>

							<input :disabled="!isEditable" class="form-control" v-model="coleccion.Titulo" type="text" id="TituloInput" placeholder="Escribe el título que deseas darle a la colección"></input>
						</div>
						<div class="form-group">

							<label>Formato de colección:</label>

							<!-- <input :disabled="!isEditable" class="form-control" type="text" v-model="coleccion.Formato" id="FormatoInput" placeholder="Formato de los cromos de la colección"></input> -->

							<select id="FormatoInput" v-model="coleccion.Formato" class="form-control" :disabled="!isEditable" placeholder="Formato de los cromos de la colección">
								<option value=1>Papel</option>
								<option value=2>Holográfica</option>
								<option value=3>3D</option>
								<option value=4>Plástico</option>
								<option value=5>Clásico</option>
							</select>
						</div>

						<div class="checkbox">

							<label>	<input :disabled="!isEditable" class="checkbox" type="checkbox" v-model="coleccion.Periodica" id="modificableInput" >Periódica</label>

						</div>

						<div class="form-inline">
							<div class="form-group">
								<label> Fecha inicio tirada:</label>
								<input :disabled="!isEditable" class="form-control" type="date" v-model="coleccion.FechaFin" id="ultimamodificacionInput"></input>

								<label>Fecha fin de tirada:</label>
								<input :disabled="!isEditable" class="form-control" type="date" v-model="coleccion.FechaInicio" id="creacionInput" ></input>

								
							</div>
						</div>
						<!-- <div class="form-group">
							<label>Tipo:</label>

							<select v-model="coleccion.Tipo" class="form-control" :disabled="!isEditable" placeholder="Selecciona el tipo de ">
								<option value=1>Papel</option>
								<option value=2>Holográfica</option>
								<option value=3>3D</option>
								<option value=4>Plástico</option>
								<option value=5>Clásico</option>
							</select>
						</div> -->
						<div class="form-group">

							<label>Número de cromos de la colección:</label>

							<input :disabled="!isEditable" class="form-control" type="number" v-model="coleccion.NumeroCromos" id="tamanioInput" ></input>
						</div>

						<div v-if="this.state==0">
							<input id="input-1a" type="file" class="file" data-show-preview="false">
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="modal-footer">
			<div id ="btnUpDel">
				<button  id="acceptButton" :disabled="this.computeAcceptButton" class="btn btn-success" v-on:click="buttonAccept"><span class="glyphicon glyphicon-ok"></span> Aceptar</button>
				<button  id="cancelarButton" class="btn btn-primary" v-on:click="buttonCancelar"><span class="glyphicon glyphicon-repeat"></span> Cancelar</button>
			</div>
		</div>
	</div>
</template>

<script>
	import constantes from './constants.js';
	export default{
		components:{
		},
		data (){
			return{
				coleccion:{
				},
				anteriorColeccion:{
				},
				isEditable:false,
				menuChoice : "ColeccionTipos",
				estaVacio : false

			}
		},
		props:[
		'state',
		'currentId'
		],
		computed:{
			computeAcceptButton: function()	{
				if(!this.isEditable){
					return  true; 
				}
				else if(this.state == constantes.STATE_NEW){
					return false;
				}
				else if(this.state == constantes.STATE_UPDATE){
					if(this.coleccion.Titulo != this.anteriorColeccion.Titulo){
						return false;
					}
					else if(this.coleccion.Formato != this.anteriorColeccion.Formato){
						return false;
					}
					else if(this.coleccion.FechaInicio != this.anteriorColeccion.FechaInicio){
						return false;
					}
					else if(this.coleccion.FechaFin != this.anteriorColeccion.FechaFin){
						return false;
					}
					// else if(this.coleccion.Tamanio != this.anteriorColeccion.Tamanio){
					// 	return false;
					// }
					else if(this.coleccion.NumeroCromos != this.anteriorColeccion.NumeroCromos){
						return false;
					}
					else if(this.coleccion.Periodica != this.anteriorColeccion.Periodica){
						return false;
					}
					else{return true;}
				}
			},
			computeDeleteButton: function(){
				if(!this.isEditable){
					return false;
				}
				else if(this.state == constantes.STATE_UPDATE){
					return true;
				}
				else {return true};
			},
		},
		methods:{
			buttonEnableEdit: function(){
				this.isEditable = !this.isEditable;
				this.anteriorColeccion = $.extend({}, this.coleccion)
			},
			buttonBorrar: function(){
				if(confirm("¿Está seguro de que quiere borrar?")){
					$.ajax({
						url:constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
						method: "DELETE"
					})
					.done(this.borradoHandler)
					.fail(function(){alert("Ha habido un error al borrar.");})
				}
			},
			buttonCancelar: function(){
				this.$emit('cancelDetail', true);

			},
			borradoHandler: function(){
				alert("Elemento borrado correctamente.");
				this.$emit('makeGet', true);
				this.makeEmptyData();
			},
			buttonAccept: function(){

				if(this.state == constantes.STATE_NEW){
					let errores = "";
					if(this.coleccion.Titulo===""){
						errores+="Escribe un título para la colección. \n";
					}
					if(this.coleccion.Formato===""){
						errores+="Selecciona un formato. \n";
					}
					if(this.coleccion.FechaInicio === "")
					{
						errores+="El valor de fecha de inicio está vacío. \n";
					}
					if(this.coleccion.FechaFin === "" )
					{
						errores+="El valor de fecha de fin está vacío. \n";
					}
					if(this.coleccion.Tipo === 0){
						errores+="El valor de Tipo no es correcto. \n";	
					} 
					// if(this.coleccion.Tamanio === ""){
					// 	errores+="Inserta un tamaño de ejemplar para la colección. \n";
					// }
					if(this.coleccion.NumeroCromos === 0){
						errores+="Inserta un número de ejemplares para la colección. \n";
					}
					if(errores != ""){
						alert("Hay campos no rellenados. No se puede crear el objeto:\n" + errores);
					}
					else{
						$.ajax({url:constantes.BASE_URL + this.menuChoice,
							method:"POST",
							data: this.coleccion})	
						.done(this.afterPostHandler)
						.fail(function(){
							alert("No se ha podido crear la colección.");
						})
					}

				}
				else if(this.state == constantes.STATE_UPDATE){
					$.ajax({url:constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
						method:"PUT",
						data: this.coleccion})
					.done(this.putSubmitData)
				}
			},
			afterPostHandler(){
				alert("La colección se ha creado con éxito.");
				this.$emit('forceUpdate', true);

				// TODO: Se fuerza un get en el maestro y se cierra el detail.
				// Podemos llamar al metodo buttonCancelar.
			},
			putSubmitData(){
				alert("Colección modificada correctamente.");
				this.anteriorColeccion = $.extend({}, this.coleccion);
				this.$emit('forceUpdate', true);

			}, 	
			makeGetRequest(){
				$.ajax({
					url: constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
					method: "GET"
				})
				.done(this.submitGetRequest)
				.fail(function(){
					alert("No se pueden mostrar los elementos.");
				})
			},
			makeEmptyData(){
				if(!this.estaVacio){
					this.coleccion = {};
					this.currentId = "";
					this.coleccion.Titulo = "";
					this.coleccion.Formato = "";
					this.coleccion.FechaInicio = "";
					this.coleccion.FechaFin = "";
					this.coleccion.Tamanio = 0;
					this.coleccion.NumeroCromos = 0;
					this.coleccion.Periodica = false;

					this.anteriorColeccion={};
					this.anteriorColeccion.Titulo = "";
					this.anteriorColeccion.Formato = "";
					this.anteriorColeccion.FechaInicio = "";
					this.anteriorColeccion.FechaFin = "";
					this.anteriorColeccion.Tamanio = 0;
					this.anteriorColeccion.NumeroCromos = 0;
					this.anteriorColeccion.Periodica = false;
				}
			},
			submitGetRequest(datos){
				this.currentId = datos.Id;
				this.coleccion = datos; 	
			},
			parseTipo: function(array){
				var _this = this;
				array.forEach(function(element, index) {
					
					if(element.Formato == 1){
						_this.lista[index].Formato = "Papel";
					}
					else if(element.Formato == 2){
						_this.lista[index].Formato = "Holográfica";
					}
					else if(element.Formato == 3){
						_this.lista[index].Formato = "3D";
					}
					else if(element.Formato == 4){
						_this.lista[index].Formato = "Plástico";
					}
					else if(element.Formato == 5){
						_this.lista[index].Formato = "Clásico";
					}
				});
			},
			makeNewDetail: function(){
				this.makeEmptyData();
				this.currentId = "";
				this.state = constantes.STATE_NEW;
				this.isEditable = true;
			},
			
		}, 
		mounted(){
			if(this.state == constantes.STATE_UPDATE){
				this.makeGetRequest();
			}
			else if(this.state == constantes.STATE_NEW){
				this.makeEmptyData(); 	
				this.estaVacio = true;
				this.isEditable = true;
			}
		},
	}
</script>

<style type="text/css">
	#btnUpDel{
		text-align: left;
	}

	hr {
		margin-top: 20px;
		margin-bottom: 20px;
		border: 0;
	}
	#alineacion{
		text-align: left;
	}
</style>