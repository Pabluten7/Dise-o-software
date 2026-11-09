package dto;

import java.util.ArrayList;
import domain.ListaElectoral;

/**
 * Assembler para convertir listas electorales de dominio en ListaResumenDTO.
 */
public class ListaResumenAssembler {

  /**
   * Convierte una lista electoral (de congreso o senado) en un DTO que incluye
   * los datos de contacto de todos sus candidatos, en orden de posición.
   * 
   * @pre lista != null
   */
  public static ListaResumenDTO toDTO(ListaElectoral lista) {

    ListaResumenDTO dto = new ListaResumenDTO();
    dto.setCandidatura(lista.getCandidatura().getNombre());
    dto.setSiglas(lista.getCandidatura().getSiglas());
    dto.setCandidatos(new ArrayList<>(lista.getCandidatos()));
    dto.setEstado(lista.getEstado().name());

    return dto;

  } // toDTO

} // ListaResumenAssembler
