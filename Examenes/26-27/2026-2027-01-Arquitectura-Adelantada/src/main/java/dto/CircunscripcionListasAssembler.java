package dto;

import domain.Circunscripcion;
import domain.ListaCongreso;
import domain.ListaElectoral;
import domain.ListaSenado;

/**
 * Assembler para construir el CircunscripcionListasDTO de una circunscripción.
 */
public class CircunscripcionListasAssembler {

  /**
   * Convierte una circunscripción en un DTO con los escaños y las listas
   * presentadas en ella tanto para el Congreso como para el Senado.
   * 
   * @pre circunscripcion != null
   */
  public static CircunscripcionListasDTO toDTO(Circunscripcion circunscripcion) {

    CircunscripcionListasDTO dto = new CircunscripcionListasDTO();
    dto.setNombre(circunscripcion.getNombre());
    dto.setEscanhosCongreso(circunscripcion.getCongresistas());
    dto.setEscanhosSenado(circunscripcion.getSenadores());

    for (ListaElectoral lista : circunscripcion.getListasPresentadas()) {
      if (lista instanceof ListaCongreso) {
        dto.getListasCongreso().add(ListaResumenAssembler.toDTO(lista));
      } else if (lista instanceof ListaSenado) {
        dto.getListasSenado().add(ListaResumenAssembler.toDTO(lista));
      } // if
    } // for

    return dto;

  } // toDTO

} // CircunscripcionListasAssembler
