package domain;

public class DatosContacto {

	protected long id;

	public long getId() { 
		return id; 
	}

	public void setId(long id) { 
		this.id = id; 
	}

	protected String nombre;
	protected String primerApellido;
	protected String segundoApellido;
	protected long telefono;
	protected String correoElectronico;

	public String getNombre() { 
		return nombre; 
	}

	public void setNombre(String nombre) { 
		this.nombre = nombre; 
	}

	public String getPrimerApellido() { 
		return primerApellido; 
	}

	public void setPrimerApellido(String primerApellido) { 
		this.primerApellido = primerApellido; 
	}

	public String getSegundoApellido() { 
		return segundoApellido; 
	}

	public void setSegundoApellido(String segundoApellido) { 
		this.segundoApellido = segundoApellido; 
	}

	public long getTelefono() { 
		return telefono; 
	}

	public void setTelefono(long telefono) { 
		this.telefono = telefono; 
	}

	public String getCorreoElectronico() { 
		return correoElectronico; 
	}

	public void setCorreoElectronico(String correoElectronico) { 
		this.correoElectronico = correoElectronico; 
	}

} // DatosContacto
