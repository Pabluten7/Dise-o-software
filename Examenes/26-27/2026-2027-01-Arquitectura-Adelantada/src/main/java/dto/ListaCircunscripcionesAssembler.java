package dto;

import domain.Circunscripcion;

/**
 * Assembler para construir el ListadoListasDTO de la pantalla de gestión de
 * listas electorales con los datos de todas las circunscripciones y ambas
 * cámaras.
 */
public class ListaCircunscripcionesAssembler {

  /**
   * @param circunscripciones todas las circunscripciones a mostrar
   * @pre circunscripciones != null
   */
  public static ListaCircunscripcionesDTO toDTO(Iterable<Circunscripcion> circunscripciones) {

    ListaCircunscripcionesDTO dto = new ListaCircunscripcionesDTO();
    for (Circunscripcion circunscripcion : circunscripciones) {
      dto.getCircunscripciones().add(CircunscripcionListasAssembler.toDTO(circunscripcion));
    } // for
    return dto;

  } // toDTO

} // ListaCircunscripcionesAssembler