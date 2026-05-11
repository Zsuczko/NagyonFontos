export type PokemonType = {
    name: string,
    image: string,
    types: {
        name: string,
        color: string,
    }[],
    health: number
}