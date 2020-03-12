import * as _ from 'lodash';
const helper = class Helpers {
    constructor() { }
    /*
    * Take sentence and summurize it
    */
    static textSummerizer(text, maxChars = 20) {
        if (text.length < maxChars)
            return text;
        let words = text.split(' ');
        let totalWords = 0;
        let summarizedWords = [];
        let BreakException = {};
        _.forEach(words, (word) => {
            summarizedWords.push(word);
            totalWords += word.length + 1;
            if (totalWords > maxChars)
                return false;
        });
        return summarizedWords.join(" ") + "...";
    }
    static passwordGenerator(passwordLength = 13) {
        let password = "";
        let combination = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        for (let i = 0; i < passwordLength; i++) {
            password += combination.charAt(Math.floor(Math.random() * combination.length));
        }
        return password;
    }
};
export default helper;
//# sourceMappingURL=Helpers.js.map