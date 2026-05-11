import { usePokemonContext } from "../context/PokeContextProvider"
import type { PokemonType } from "../types/PokeType"
import styles from "./PokeBall.module.css"

type PokeBallProps = {
    pokemon: PokemonType
}

const PokeBall = ({pokemon}:PokeBallProps) => {
  const {setSelectedPokemon} = usePokemonContext()

  return (
    <button className={styles.pokeBall} onClick={()=>setSelectedPokemon(pokemon)}>
        <img src={pokemon.image} alt={pokemon.name} />
    </button>
  )
}

export default PokeBall