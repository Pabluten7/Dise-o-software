package dataMapper;

import java.util.HashSet;
import java.util.Set;

import domain.DatosContacto;
import domain.Impugnacion;
import exceptions.PersistenceException;

/**
 * Data Mapper para la entidad Impugnacion.
 */
public class ImpugnacionDataMapper {

  /**
   * Recupera las impugnaciones presentadas contra una lista electoral.
   * 
   * @param listaId identificador de la lista electoral
   * @return las impugnaciones de la lista
   * @throws PersistenceException si ocurre un error de persistencia
   */
  public Set<Impugnacion> findByListaId(long listaId) throws PersistenceException {
    DatosContacto impugnante = new DatosContacto();
    impugnante.setId(100);
    impugnante.setNombre("Ana");
    impugnante.setPrimerApellido("Lopez");
    impugnante.setSegundoApellido("Diaz");
    impugnante.setTelefono(600000000L);
    impugnante.setCorreoElectronico("ana@example.com");

    Impugnacion impugnacion = new Impugnacion();
    impugnacion.setMotivacion("Impugnacion ficticia");
    impugnacion.setImpugnante(impugnante);

    Set<Impugnacion> impugnaciones = new HashSet<Impugnacion>();
    impugnaciones.add(impugnacion);
    return impugnaciones;
  } // findByListaId

} // ImpugnacionDataMapper
