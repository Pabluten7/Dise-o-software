package domain;

import java.util.ArrayList;
import java.util.List;

public class ListaSenado extends ListaElectoral {

	protected List<DatosContacto> senadores = new ArrayList<>();

	public List<DatosContacto> getSenadores() {
		return senadores;
	}

	public void setSenadores(List<DatosContacto> senadores) {
		this.senadores = senadores;
	}

	@Override
	public List<DatosContacto> getCandidatos() {
		return getSenadores();
	}

} // ListaSenado
