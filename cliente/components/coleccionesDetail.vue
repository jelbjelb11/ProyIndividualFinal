<template>


	<div class="modal-content">
		<div class="modal-header">
			<button type="button" class="close" data-dismiss="modal" v-on:click="buttonCancelar">Cerrar &times;</button>
		</div>
		<div class="modal-body">
			<div id="Detail" class="detail-div">
				<div id ="FormularioCromos" class="mx-auto">
					<div id ="btnUpDel" class="form-group">
						<button :disabled="this.isEditable" id="enableEditButton" class="btn btn-primary" v-on:click="buttonEnableEdit"><span class="glyphicon glyphicon-pencil"></span> Modificar</button>
						<button  id="borrarButton" :disabled="this.computeDeleteButton" class="btn btn-danger" v-on:click="buttonBorrar"><span class="glyphicon glyphicon-trash"></span>Borrar</button>
					</div>
					<div class="form-group">
						<div id="izq">
							<label for="Nombre">Título de la colección:</label>
						</div>
						<input :disabled="!isEditable" class="form-control" v-model="documento.Titulo" type="text" id="TituloInput" placeholder="Titulo"></input>
					</div>
					<div class="form-group">
						<div id="izq">
							<label>Formato de colección:</label>
						</div>
						<input :disabled="!isEditable" class="form-control" type="text" v-model="documento.Formato" id="FormatoInput" placeholder="Formato"></input>
					</div>
					<div class="checkbox">
						<div id="izq">
							<label>	<input :disabled="!isEditable" class="checkbox" type="checkbox" v-model="documento.Periodica" id="modificableInput" >Periódica</label>
						</div>
					</div>
					

					<div id="izq">
						<div class="form-inline">
							<div class="form-group">
								<label>Fecha fin de tirada:</label>
								<input :disabled="!isEditable" class="form-control" type="date" v-model="documento.FechaInicio" id="creacionInput" ></input>

								<label>Fecha inicio tirada:</label>
								<input :disabled="!isEditable" class="form-control" type="date" v-model="documento.FechaFin" id="ultimamodificacionInput"></input>


							</div>
						</div>
					</div>
					<hr>
					<div class="form-group">
						<div id="izq">
							<label>Tamaño del cromo:</label>
						</div>
						<input :disabled="!isEditable" class="form-control" type="number" v-model="documento.Tamanio" id="tamanioInput" ></input>
					</div>
					<div>
						<div id="izq">
							<label>Tipo:</label>
						</div>
						<select v-model="documento.Tipo" class="form-control" :disabled="!isEditable">
							<option value=1>Texto plano</option>
							<option value=2>Imagen</option>
							<option value=3>PDF</option>
							<option value=4>Hoja de cálculo</option>
							<option value=5>Documento de Word</option>
						</select>
					</div>
					<hr>
					<div v-if="this.state==0">
						<input id="input-1a" type="file" class="file" data-show-preview="false">
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
				documento:{
				},
				previousDocument:{
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
					if(this.documento.Titulo != this.previousDocument.Titulo){
						return false;
					}
					else if(this.documento.Formato != this.previousDocument.Formato){
						return false;
					}
					else if(this.documento.FechaInicio != this.previousDocument.FechaInicio){
						return false;
					}
					else if(this.documento.FechaFin != this.previousDocument.FechaFin){
						return false;
					}
					else if(this.documento.Tipo != this.previousDocument.Tipo){
						return false;
					}
					else if(this.documento.Tamanio != this.previousDocument.Tamanio){
						return false;
					}
					else if(this.documento.Periodica != this.previousDocument.Periodica){
						return false;
					}
					else{return true;}
				}
			},
			computeDeleteButton: function(){
				if(!this.isEditable){
					return true;
				}
				else if(this.state == constantes.STATE_UPDATE){
					return false;
				}
				else {return true};
			},
		},
		methods:{
			buttonEnableEdit: function(){
				this.isEditable = !this.isEditable;
				this.previousDocument = $.extend({}, this.documento)
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
					if(this.documento.Titulo===""){
						errores+="El valor de Título está vacío. \n";
					}
					if(this.documento.Formato===""){
						errores+="El valor de Formato está vacío. \n";
					}
					if(this.documento.FechaInicio === "")
					{
						errores+="El valor de Fecha de Creación está vacío. \n";
					}
					if(this.documento.FechaFin === "" )
					{
						errores+="El valor de Última Modificación está vacío. \n";
					}
					if(this.documento.Tipo === 0){
						errores+="El valor de Tipo no es correcto. \n";	
					} 
					if(this.documento.Tamanio === 0){
						errores+="El valor de Tamaño es 0. \n";
					}
					if(errores != ""){
						alert("Hay campos no rellenados. No se puede crear el objeto:\n" + errores);
					}
					else{
						$.ajax({url:constantes.BASE_URL + this.menuChoice,
							method:"POST",
							data: this.documento})	
						.done(this.afterPostHandler)
						.fail(function(){
							alert("Fallo en la creacion del elemento");
						//TODO: Gestionar los fallos
					})
					}

				}
				else if(this.state == constantes.STATE_UPDATE){
					$.ajax({url:constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
						method:"PUT",
						data: this.documento})
					.done(this.putSubmitData)
				}
			},
			afterPostHandler(){
				alert("Elemento creado");
				this.$emit('forceUpdate', true);

				// TODO: Se fuerza un get en el maestro y se cierra el detail.
				// Podemos llamar al metodo buttonCancelar.
			},
			putSubmitData(){
				alert("Elemento modificado");
				this.previousDocument = $.extend({}, this.documento);
				this.$emit('forceUpdate', true);

			}, 	
			makeGetRequest(){
				$.ajax({
					url: constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
					method: "GET"
				})
				.done(this.submitGetRequest)
				.fail(function(){
					alert("Ha fallado la carga del objeto");
				})
			},
			makeEmptyData(){
				if(!this.estaVacio){
					this.documento = {};
					this.currentId = "";
					this.documento.Titulo = "";
					this.documento.Formato = "";
					this.documento.FechaInicio = "";
					this.documento.FechaFin = "";
					this.documento.Tamanio = 0;
					this.documento.Tipo = 0;
					this.documento.Periodica = false;

					this.previousDocument={};
					this.previousDocument.Titulo = "";
					this.previousDocument.Formato = "";
					this.previousDocument.FechaInicio = "";
					this.previousDocument.FechaFin = "";
					this.previousDocument.Tamanio = 0;
					this.previousDocument.Tipo = 0;
					this.previousDocument.Periodica = false;
				}
			},
			submitGetRequest(datos){
				this.currentId = datos.Id;
				this.documento = datos; 	
			},
			parseTipo: function(array){
				var _this = this;
				array.forEach(function(element, index) {
					
					if(element.Tipo == 2){
						_this.lista[index].Tipo = "Imagen";
					}
					else if(element.Tipo == 3){
						_this.lista[index].Tipo = "PDF";
					}
					else if(element.Tipo == 4){
						_this.lista[index].Tipo = "Hoja de cálculo";
					}
					else if(element.Tipo == 5){
						_this.lista[index].Tipo = "Documento de Word";
					}
					else if(element.Tipo == 1){
						_this.lista[index].Tipo = "Texto";
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

<style>
	#btnUpDel{
		text-align: left;
	}

	hr {
		margin-top: 20px;
		margin-bottom: 20px;
		border: 0;
		/* border-top: 1px solid #eee; */
	}
	#izq{
		text-align: left;
	}
</style>