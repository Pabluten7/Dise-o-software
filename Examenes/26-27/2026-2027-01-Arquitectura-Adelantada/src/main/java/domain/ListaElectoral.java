package domain;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

public abstract class ListaElectoral {

	protected long id;
	protected EstadoLista estado;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	protected Candidatura candidatura;
	protected Circunscripcion presentadaEn;
	protected Set<Impugnacion> impugnaciones = new HashSet<Impugnacion>();

	public EstadoLista getEstado() {
		return estado;
	}

	public void setEstado(EstadoLista estado) {
		this.estado = estado;
	}

	public Candidatura getCandidatura() {
		return candidatura;
	}

	public void setCandidatura(Candidatura candidatura) {
		this.candidatura = candidatura;
	}

	public Circunscripcion getPresentadaEn() {
		return presentadaEn;
	}

	public void setPresentadaEn(Circunscripcion presentadaEn) {
		this.presentadaEn = presentadaEn;
	}

	public Set<Impugnacion> getImpugnaciones() {
		return impugnaciones;
	}

	public void setImpugnaciones(Set<Impugnacion> impugnaciones) {
		this.impugnaciones = impugnaciones;
	}

	public abstract List<DatosContacto> getCandidatos();

} // ListaElectoral
