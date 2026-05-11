import {
  createContext,
  useContext,
  useEffect,
  useState,
  type ReactNode,
} from "react";
import type { PokemonType } from "../types/PokeType";

type PokemonContextType = {
  pokemonsData: PokemonType[];
  selectedPokemon: PokemonType;
  nextPokemon: () => void;
  prevPokemon: () => void;
  setSelectedPokemon: (pokemon: PokemonType) => void;
};

const PokemonContext = createContext<PokemonContextType | undefined>(undefined);

const dummyData: PokemonType[] = [
  {
    name: "charmander",
    image:
      "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png",
    types: [{ name: "fire", color: "#F08030" }],
    health: 0.5,
  },
  {
    name: "squirtle",
    image:
      "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/7.png",
    types: [{ name: "water", color: "#6890F0" }],
    health: 4.0,
  },
];

const PokeContextProvider = ({ children }: { children: ReactNode }) => {
  const [pokemonsData, setPokemonsData] = useState<PokemonType[]>([]);
  const [selectedPokemon, setSelectedPokemon] = useState<PokemonType>(
    dummyData[0],
  );

  // TODO: itt kell a json-ból olvasni
  useEffect(() => {
    fetch("/pokemons.json")
      .then((res) => res.json())
      .then((data) => {
        {
          setPokemonsData(data);
          setSelectedPokemon(data[0]);
        }
      });
  }, []);

  const nextPokemon = () => {
    const currentIndex =
      pokemonsData?.findIndex(
        (pokemon) => pokemon.name === selectedPokemon.name,
      ) ?? 0;
    const nextIndex = (currentIndex + 1) % (pokemonsData?.length ?? 1);
    setSelectedPokemon(pokemonsData ? pokemonsData[nextIndex] : dummyData[0]);
  };

  const prevPokemon = () => {
    const currentIndex =
      pokemonsData?.findIndex(
        (pokemon) => pokemon.name === selectedPokemon.name,
      ) ?? 0;
    const prevIndex =
      (currentIndex - 1 + (pokemonsData?.length ?? 1)) %
      (pokemonsData?.length ?? 1);
    setSelectedPokemon(pokemonsData ? pokemonsData[prevIndex] : dummyData[0]);
  };

  return (
    <PokemonContext.Provider
      value={{
        pokemonsData,
        selectedPokemon,
        nextPokemon,
        prevPokemon,
        setSelectedPokemon,
      }}
    >
      {children}
    </PokemonContext.Provider>
  );
};

export const usePokemonContext = () => {
  const context = useContext(PokemonContext);

  if (!context) {
    throw new Error(
      "usePokemonContext must be used within a PokemonContextProvider",
    );
  }

  return context;
};

export default PokeContextProvider;
