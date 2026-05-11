# Feladatok

## PokeBall mapping - 2 pont

Módosítsa az src/ mappában található App.tsx komponenst úgy, hogy a usePokemonContext custom hook-ot használva kiválasztja a pokemonsData értékét (ez a pokémonokat tartalmazó lista lesz), majd ezen végigmappelve PokeBall-okat (be kell importálni!) jelenít meg a kijelölt területen. A PokeBall-ok kulcs értéke az adott pokémon id-ja legyen.

## Adatok beolvasása API-ból - 4 pont

- Egészítse ki a src/context/ mappában lévő PokeContextProvider komponenst úgy, hogy a pokémonok adatai ne a dummyData alapján jelenjenek meg, hanem a pokemons.json fájlból beolvasva (fetch vagy axios, mivel a vizsgán az adatok backendtől fognak érkezni...) - 2p

- A sikeres lekérés után frissítse a pokeData state-t a kapott adatokkal, valamint állítsa be a selectedPokemon state-t a beolvasott tömb első elemére. - 2p

## Health komponens - 9 pont

Készítsen egy újrahasznosítható React komponenst, amely egy pokémon életét jeleníti meg, 5 szív ikonnal!

- Hozza létre az src/components/Health.tsx fájlban a Health komponenst és exportálja! - 2p

- A komponens propsként kapjon meg egy számot, ami egy adott pokémon életét fogja jelezni a [0,5] intervallumon (lehet tört szám is!). - 1p

- A program által visszaadott elem egy div legyen, amelyet a health osztállyal lásson el. - 1p

- Írja meg a program logikáját: A kimenet minden alkalommal pontosan 5 élet ikonból álljon, de az élet kitöltése a props-ként átadott számtól függjön. Az életek kirajzolásához használja a fent létrehozott konstansokat. - 3p

*Példa: Venosaur-nak 3.8 élete van, ami azt jelenti, hogy van 3 teli életcellája (fullHeart), egy sérült életcellája (crackedHeart) és egy üres életcellája (emptyHeart).*

- Az src/ mappában található App komponensben használja fel az imént létrehozott Health komponenst a megjelölt melyen. A komponensnek átadott érték a selectedPokemon.health legyen, vagy ennek hiányában a 0 szám. - 2p

![Design image](/design.PNG)

![Mobile Design image](/mobile-design.PNG)

# CSS feladatok

Az exam.css fájlba írja meg, hogy a .pokeBallWrapper osztályú elem egy grid szerkezetet vegyen fel, és 10px-es hézaggal 5 oszlopban jelenjen meg.

Ugyan ez az elem 600px-es ablakszélesség alatt 3 oszlopban jelenjen meg.
