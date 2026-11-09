package domain;

import java.util.HashSet;
import java.util.Set;

public class Coalicion extends Candidatura {

	protected Set<PartidoPolitico> integrantes = new HashSet<PartidoPolitico>();

	public Set<PartidoPolitico> getIntegrantes() { 
		return integrantes; 
	}

	public void setIntegrantes(Set<PartidoPolitico> integrantes) { 
		this.integrantes = integrantes; 
	}

} // Coalicion
