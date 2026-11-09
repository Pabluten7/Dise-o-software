package dto;

import java.util.ArrayList;
import java.util.List;

import domain.DatosContacto;

/**
 * Data Transfer Object con los datos de una fila de la tabla de listas
 * electorales de la interfaz de gestión de listas.
 */
public class ListaResumenDTO {

  /** Nombre de la candidatura que presenta la lista. */
  protected String candidatura;

  /** Siglas de la candidatura. */
  protected String siglas;

  /**
   * Candidatos de la lista, en orden de posición. Son titulares los primeros
   * tantos como escaños tenga la circunscripción en la cámara; el resto son
   * suplentes. El cabeza de lista es el primero.
   */
  protected List<DatosContacto> candidatos = new ArrayList<>();

  /** Estado de la lista (BORRADOR, PRESENTADA, PROCLAMADA, EXCLUIDA). */
  protected String estado;

  public ListaResumenDTO() {
  }

  public String getCandidatura() {
    return candidatura;
  }

  public void setCandidatura(String candidatura) {
    this.candidatura = candidatura;
  }

  public String getSiglas() {
    return siglas;
  }

  public void setSiglas(String siglas) {
    this.siglas = siglas;
  }

  public List<DatosContacto> getCandidatos() {
    return candidatos;
  }

  public void setCandidatos(List<DatosContacto> candidatos) {
    this.candidatos = candidatos;
  }

  public String getEstado() {
    return estado;
  }

  public void setEstado(String estado) {
    this.estado = estado;
  }

} // ListaResumenDTO
