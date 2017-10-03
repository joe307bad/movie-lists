import { Base } from "./base";
import { User } from "./user";
import { Movie } from "./movie";

export interface Rating extends Base {
    Score: Score,
    User: User,
    Movie: Movie
}

export enum Score {
    UNRATED,
    ZERO_STARS,
    ONE_STAR,
    TWO_STARS,
    THREE_STARS,
    FOUR_STARS,
    FIVE_STARS
}