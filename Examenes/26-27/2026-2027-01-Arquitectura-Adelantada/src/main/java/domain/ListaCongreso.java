package domain;

import java.util.ArrayList;
import java.util.List;

public class ListaCongreso extends ListaElectoral {

	protected List<DatosContacto> congresistas = new ArrayList<DatosContacto>();

	public List<DatosContacto> getCongresistas() {
		return congresistas;
	}

	public void setCongresistas(List<DatosContacto> congresistas) {
		this.congresistas = congresistas;
	}

	/**
	 * Añade un candidato al final de la lista si esta está en borrador.
	 * Las posiciones que superan el número de
	 * congresistas de la circunscripción son suplentes.
	 * 
	 * @param candidato El candidato a añadir.
	 * 
	 * @Pre: candidato != null
	 */
	public ResultadoInclusion addCandidato(DatosContacto candidato) {

		ResultadoInclusion result = ResultadoInclusion.EXCLUIDO;

		if (estado == EstadoLista.BORRADOR) {

			getCongresistas().add(candidato);

			int titulares = this.presentadaEn.getCongresistas();

			if (getCongresistas().size() <= titulares) {
				result = ResultadoInclusion.TITULAR;
			} else {
				result = ResultadoInclusion.SUPLENTE;
			}
		}

		return result;

	} // addCandidato

	@Override
	public List<DatosContacto> getCandidatos() {
		return getCongresistas();
	}

} // ListaCongreso
