var gulp = require("gulp"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uncss = require("gulp-uncss"),
    browserSync = require("browser-sync").create();

gulp.task("browser-sync", function() {
  browserSync.init({
    proxy: "localhost:5000"
  });

  gulp.watch("./styles/*.css", ["css"]);
  gulp.watch("./js/*.js", ["js"]);
});

gulp.task("js", function() {
  return gulp
    .src([
      "./node_modules/jquery/dist/jquery.min.js",
      "./node_modules/jquery-validation/dist/jquery.validate.min.js",
      "./node_modules/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js",
      "./node_modules/bootstrap/dist/js/bootstrap.min.js",
      "./node_modules/jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.min.js",
      "./Js/site.js"
    ])
    .pipe(gulp.dest("wwwroot/js/"))
    .pipe(browserSync.stream());
});

gulp.task("css", function() {
  return gulp
    .src([
      "./Styles/site.css",
      "./node_modules/bootstrap/dist/css/bootstrap.min.css"
    ])
    .pipe(concat("site.min.css"))
    .pipe(cssmin())
    .pipe(uncss({ html: ["Views/**/*.cshtml"] }))
    .pipe(gulp.dest("wwwroot/css"))
    .pipe(browserSync.stream());
});
