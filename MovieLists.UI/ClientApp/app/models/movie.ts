import { Base } from "./base";
import { Rating } from "./rating";

export interface Movie extends Base{
    ImdbId: string,
    Title: string,
    Release: Date,
    PoserUrl: string,
    UserRating: Rating,
    AverageOverallRating: number
}