package dto;

import java.util.ArrayList;
import java.util.List;

/**
 * Data Transfer Object con los datos de una circunscripción en la pantalla de
 * gestión de listas electorales.
 */
public class CircunscripcionListasDTO {

  /** Nombre de la circunscripción. */
  protected String nombre;

  /** Escaños a elegir en el Congreso. */
  protected int escanhosCongreso;

  /** Escaños a elegir en el Senado. */
  protected int escanhosSenado;

  /** Filas de la tabla de listas al Congreso. */
  protected List<ListaResumenDTO> listasCongreso = new ArrayList<>();

  /** Filas de la tabla de listas al Senado. */
  protected List<ListaResumenDTO> listasSenado = new ArrayList<>();

  public CircunscripcionListasDTO() {
  }

  public String getNombre() {
    return nombre;
  }

  public void setNombre(String nombre) {
    this.nombre = nombre;
  }

  public int getEscanhosCongreso() {
    return escanhosCongreso;
  }

  public void setEscanhosCongreso(int escanhosCongreso) {
    this.escanhosCongreso = escanhosCongreso;
  }

  public int getEscanhosSenado() {
    return escanhosSenado;
  }

  public void setEscanhosSenado(int escanhosSenado) {
    this.escanhosSenado = escanhosSenado;
  }

  public List<ListaResumenDTO> getListasCongreso() {
    return listasCongreso;
  }

  public void setListasCongreso(List<ListaResumenDTO> listasCongreso) {
    this.listasCongreso = listasCongreso;
  }

  public List<ListaResumenDTO> getListasSenado() {
    return listasSenado;
  }

  public void setListasSenado(List<ListaResumenDTO> listasSenado) {
    this.listasSenado = listasSenado;
  }

} // CircunscripcionListasDTO
