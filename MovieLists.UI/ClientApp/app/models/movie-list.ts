import { List } from "immutable/dist";
import { User } from "./user";
import { Base } from "./base";

export interface MovieList extends Base{
    Name: string,
    User: User,
    Movies: List<Movie>,
    NumOfMovies: number,
    AverageRatung: number
}