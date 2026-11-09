package domain;

public class Impugnacion {

	protected String motivacion;
	protected DatosContacto impugnante;

	public String getMotivacion() { 
		return motivacion; 
	}
	
	public void setMotivacion(String motivacion) { 
		this.motivacion = motivacion; 
	}

	public DatosContacto getImpugnante() { 
		return impugnante; 
	}

	public void setImpugnante(DatosContacto impugnante) { 
		this.impugnante = impugnante; 
	}

} // Impugnacion
