package proxy;

import java.util.List;
import java.util.Set;

import dataMapper.DatosContactoDataMapper;
import dataMapper.ImpugnacionDataMapper;
import domain.DatosContacto;
import domain.Impugnacion;
import domain.ListaCongreso;
import exceptions.PersistenceException;

/**
 * Proxy de ListaCongreso. Las referencias de multiplicidad mayor que 1
 * (congresistas e impugnaciones) se cargan con Lazy Load la primera vez que
 * se accede a ellas. El resto de atributos los establece el DataMapper al
 * crear el proxy.
 */
public class ListaCongresoProxy extends ListaCongreso {

  protected boolean congresistasLoaded = false;
  protected boolean impugnacionesLoaded = false;

  @Override
  public List<DatosContacto> getCongresistas() {

    if (!congresistasLoaded) {
      try {
        congresistas = new DatosContactoDataMapper().findCongresistasByListaId(id);
      } catch (PersistenceException e) {
        throw new RuntimeException("Error al cargar los congresistas de la lista con id " + id, e);
      } // try
      congresistasLoaded = true;
    } // if

    return congresistas;

  } // getCongresistas

  @Override
  public void setCongresistas(List<DatosContacto> congresistas) {
    super.setCongresistas(congresistas);
    congresistasLoaded = true;
  } // setCongresistas

  @Override
  public Set<Impugnacion> getImpugnaciones() {

    if (!impugnacionesLoaded) {
      try {
        impugnaciones = new ImpugnacionDataMapper().findByListaId(id);
      } catch (PersistenceException e) {
        throw new RuntimeException("Error al cargar las impugnaciones de la lista con id " + id, e);
      } // try
      impugnacionesLoaded = true;
    } // if

    return impugnaciones;

  } // getImpugnaciones

  @Override
  public void setImpugnaciones(Set<Impugnacion> impugnaciones) {
    super.setImpugnaciones(impugnaciones);
    impugnacionesLoaded = true;
  } // setImpugnaciones

} // ListaCongresoProxy
