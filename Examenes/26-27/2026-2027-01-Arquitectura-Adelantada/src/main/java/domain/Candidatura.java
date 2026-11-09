package domain;

import java.util.HashSet;
import java.util.Set;

public abstract class Candidatura {

	protected long id;
	protected String nombre;

	public long getId() { 
		return id; 
	}

	public void setId(long id) { 
		this.id = id; 
	}
	protected String siglas;
	protected DatosContacto datosRepresentante;
	protected Set<ListaElectoral> presentaListas = new HashSet<ListaElectoral>();

	public String getNombre() { 
		return nombre; 
	}
	
	public void setNombre(String nombre) { 
		this.nombre = nombre; 
	
	}

	public String getSiglas() { 
		return siglas; 
	}
	
	public void setSiglas(String siglas) { 
		this.siglas = siglas; 
	}

	public DatosContacto getDatosRepresentante() { 
		return datosRepresentante; 
	}

	public void setDatosRepresentante(DatosContacto datosRepresentante) {
		 this.datosRepresentante = datosRepresentante; 
	}
	
	public Set<ListaElectoral> getPresentaListas() { 
		return presentaListas; 
	}

	public void setPresentaListas(Set<ListaElectoral> presentaListas) { 			
		this.presentaListas = presentaListas; 
	} 

} // Candidatura
