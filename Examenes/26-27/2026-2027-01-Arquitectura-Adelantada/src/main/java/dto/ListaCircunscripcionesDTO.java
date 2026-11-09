package dto;

import java.util.ArrayList;
import java.util.List;

/**
 * Data Transfer Object con los datos de la pantalla de gestión de listas
 * electorales para todas las circunscripciones.
 */
public class ListaCircunscripcionesDTO {

  /** Datos de cada circunscripción, con sus escaños y sus listas. */
  protected List<CircunscripcionListasDTO> circunscripciones = new ArrayList<>();

  public ListaCircunscripcionesDTO() {
  }

  public List<CircunscripcionListasDTO> getCircunscripciones() {
    return circunscripciones;
  }

  public void setCircunscripciones(List<CircunscripcionListasDTO> circunscripciones) {
    this.circunscripciones = circunscripciones;
  }

} // ListaCircunscripcionesDTO
