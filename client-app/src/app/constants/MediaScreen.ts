import { createMedia } from "@artsy/fresnel";

export const AppMedia = createMedia({
    breakpoints: {
      mobile: 320,
     // tablet: 70,
      computer: 992,
      largeScreen: 1200,
      widescreen: 1920
    }
  });

