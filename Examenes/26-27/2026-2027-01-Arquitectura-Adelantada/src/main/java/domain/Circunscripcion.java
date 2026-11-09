package domain;

import java.util.HashSet;
import java.util.Set;

public class Circunscripcion {

	protected String nombre;
	protected int congresistas;
	protected int senadores;
	protected Set<ListaElectoral> listasPresentadas = new HashSet<ListaElectoral>();

	public String getNombre() { 
		return nombre; 
	}

	public void setNombre(String nombre) { 
		this.nombre = nombre; 
	}

	public int getCongresistas() { 
		return congresistas; 
	}

	public void setCongresistas(int congresistas) { 
		this.congresistas = congresistas; 
	}

	public int getSenadores() { 
		return senadores; 
	}

	public void setSenadores(int senadores) { 
		this.senadores = senadores; 
	}

	public Set<ListaElectoral> getListasPresentadas() { 
		return listasPresentadas; 
	}

	public void setListasPresentadas(Set<ListaElectoral> listasPresentadas) { 
		this.listasPresentadas = listasPresentadas; 
	}
} // Circunscripcion
