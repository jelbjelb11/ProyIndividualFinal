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

							<label for="Nombre">Razón social:</label>

							<input :disabled="!isEditable" class="form-control" v-model="distribuidor.RazonSocial" type="text" id="TituloInput" placeholder="Escribe el título que deseas darle a la colección"></input>
						</div>
						<div class="form-group">

							<label>CIF:</label>

							<input :disabled="!isEditable" class="form-control" type="text" v-model="distribuidor.CIF" id="FormatoInput" placeholder="Formato de los cromos de la colección"></input>
						</div>

						<div class="checkbox">

							<label>	<input :disabled="!isEditable" class="checkbox" type="checkbox" v-model="distribuidor.Activa" id="modificableInput">Activo</label>

						</div>

						<div class="form-inline">
							<div class="form-group">	
								<label>Teléfono:</label>
								<input :disabled="!isEditable" class="form-control" type="text" v-model="distribuidor.Telefono" id="FormatoInput" placeholder="Formato de los cromos de la colección"></input>
								<label>Persona de contacto:</label>
								<input :disabled="!isEditable" class="form-control" type="text" v-model="distribuidor.NombreContacto" id="ultimamodificacionInput"></input>
							</div>
						</div>

						<div class="form-group">
							<label>Domicilio social:</label>
							<input :disabled="!isEditable" class="form-control" type="text" v-model="distribuidor.DomicilioSocial" id="creacionInput" ></input>
							
						</div>

						<div class="form-group">

							<label>E-mail:</label>
							<input :disabled="!isEditable" class="form-control" type="text" v-model="distribuidor.Email" id="FormatoInput" placeholder="Formato de los cromos de la colección"></input>
						</div>

						<div class="form-group">

							<label>Página web:</label>
							<input :disabled="!isEditable" class="form-control" type="text" v-model="distribuidor.Web" id="FormatoInput" placeholder="Formato de los cromos de la colección"></input>
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
				distribuidor:{
				},
				anteriorDistribuidor:{
				},
				isEditable:false,
				menuChoice : "DistribuidorEmpresas",
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
					if(this.distribuidor.Titulo != this.anteriorDistribuidor.Titulo){
						return false;
					}
					else if(this.distribuidor.Formato != this.anteriorDistribuidor.Formato){
						return false;
					}
					else if(this.distribuidor.FechaInicio != this.anteriorDistribuidor.FechaInicio){
						return false;
					}
					else if(this.distribuidor.FechaFin != this.anteriorDistribuidor.FechaFin){
						return false;
					}
					else if(this.distribuidor.Tipo != this.anteriorDistribuidor.Tipo){
						return false;
					}
					else if(this.distribuidor.Tamanio != this.anteriorDistribuidor.Tamanio){
						return false;
					}
					else if(this.distribuidor.Periodica != this.anteriorDistribuidor.Periodica){
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
				this.anteriorDistribuidor = $.extend({}, this.distribuidor)
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
					if(this.distribuidor.RazonSocial===""){
						errores+="El campo de Razón Social está vacío. \n";
					}
					if(this.distribuidor.CIF===""){
						errores+="El campo del CIF está vacío. \n";
					}
					if(this.distribuidor.DomicilioSocial === "")
					{
						errores+="El campo de Domicilio Social está vacío. \n";
					}
					if(this.distribuidor.NombreContacto === "" )
					{
						errores+="Introduzca una persona de contacto. \n";
					}
					if(this.distribuidor.Telefono === ""){
						errores+="El campo del Teléfono está vacío. \n";	
					} 
					if(this.distribuidor.Email === ""){
						errores+="Introduzca un e-mail de contacto. \n";
					}
					if(this.distribuidor.Web === ""){
						errores+="Intorduzca un página Web. \n";
					}
					if(errores != ""){
						alert("Hay campos incompletos o erroneos. No se puede crear el objeto:\n" + errores);
					}
					else{
						$.ajax({url:constantes.BASE_URL + this.menuChoice,
							method:"POST",
							data: this.distribuidor})	
						.done(this.afterPostHandler)
						.fail(function(){
							alert("Fallo en la creacion del elemento");

						})
					}

				}
				else if(this.state == constantes.STATE_UPDATE){
					$.ajax({url:constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
						method:"PUT",
						data: this.distribuidor})
					.done(this.putSubmitData)
				}
			},
			afterPostHandler(){
				alert("Elemento creado");
				this.$emit('forceUpdate', true);
			},
			putSubmitData(){
				alert("Elemento modificado");
				this.anteriorDistribuidor = $.extend({}, this.distribuidor);
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
					this.distribuidor = {};
					this.currentId = "";
					this.distribuidor.RazonSocial = "";
					this.distribuidor.CIF = "";
					this.distribuidor.DomicilioSocial = "";
					this.distribuidor.NombreContacto = "";
					this.distribuidor.Telefono = "";
					this.distribuidor.Email = "";
					this.distribuidor.Web = "";
					this.distribuidor.Activa = false;

					this.anteriorDistribuidor={};
					this.anteriorDistribuidor.RazonSocial = "";
					this.anteriorDistribuidor.CIF = "";
					this.anteriorDistribuidor.DomicilioSocial = "";
					this.anteriorDistribuidor.NombreContacto = "";
					this.anteriorDistribuidor.Telefono = "";
					this.anteriorDistribuidor.Email = "";
					this.anteriorDistribuidor.Web = "";
					this.anteriorDistribuidor.Activa = false;
				}
			},
			submitGetRequest(datos){
				this.currentId = datos.Id;
				this.distribuidor = datos; 	
			},
			parseTipo: function(array){
				var _this = this;
				array.forEach(function(element, index) {
					
					if(element.Tipo == 1){
						_this.lista[index].Tipo = "Papel";
					}
					else if(element.Tipo == 2){
						_this.lista[index].Tipo = "Holográfica";
					}
					else if(element.Tipo == 3){
						_this.lista[index].Tipo = "3D";
					}
					else if(element.Tipo == 4){
						_this.lista[index].Tipo = "Plástico";
					}
					else if(element.Tipo == 5){
						_this.lista[index].Tipo = "Clásico";
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
	}
	#alineacion{
		text-align: left;
	}
</style>