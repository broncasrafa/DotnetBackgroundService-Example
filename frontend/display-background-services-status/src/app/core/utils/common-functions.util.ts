export function sortBy(property: any) {
    return function(a: any, b: any) {
        return (a[property] < b[property]) ? -1 : (a[property] > b[property]) ? 1 : 0;
    }
 }