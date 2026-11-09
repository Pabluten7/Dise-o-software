package repositories;

import domain.Circunscripcion;
import domain.DatosContacto;
import domain.EstadoLista;
import domain.ListaCongreso;
import domain.PartidoPolitico;

/**
 * Repositorio (mock) para las listas electorales.
 */
public class ListaElectoralRepository {

  /**
   * Busca una lista al congreso por su identificador.
   * 
   * Se trata de un metodo ficticio: para el identificador 0 devuelve una lista
   * en borrador con tres congresistas y para el 1 una con seis. El 2 devuelve
   * una lista presentada con tres congresistas. Todas se
   * presentan en Cantabria (5 congresistas y 3 senadores). Para cualquier otro
   * identificador devuelve null.
   */
  public static ListaCongreso findListaCongresoById(long listaId) {

    if (listaId < 0 || listaId > 2) {
      return null;
    }

    Circunscripcion cantabria = new Circunscripcion();
    cantabria.setNombre("Cantabria");
    cantabria.setCongresistas(5);
    cantabria.setSenadores(3);

    PartidoPolitico partido = new PartidoPolitico();
    partido.setId(1);
    partido.setNombre("Partido de ejemplo");

    ListaCongreso lista = new ListaCongreso();
    lista.setId(listaId);
    lista.setEstado(listaId == 2 ? EstadoLista.PRESENTADA : EstadoLista.BORRADOR);
    lista.setCandidatura(partido);
    lista.setPresentadaEn(cantabria);
    cantabria.getListasPresentadas().add(lista);
    partido.getPresentaListas().add(lista);

    int numCongresistas = (listaId == 1) ? 6 : 3;
    for (int i = 1; i <= numCongresistas; i++) {
      DatosContacto congresista = new DatosContacto();
      congresista.setId(listaId * 100 + i);
      congresista.setNombre("Congresista " + i);
      lista.getCongresistas().add(congresista);
    }

    return lista;

  } // findListaCongresoById

} // ListaElectoralRepository
