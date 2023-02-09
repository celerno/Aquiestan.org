const gulp = require('gulp'),
        sass = require('gulp-sass')(require('sass'));
        cssmin = require("gulp-cssmin")
        rename = require("gulp-rename");

gulp.task('min', function (done) {
    gulp.src('assets/scss/style.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(cssmin())
        .pipe(rename({
            suffix: ".min"
        }))
        .pipe(gulp.dest('wwwroot/assets/css'));
    done();
});
gulp.task('copy-img', function () {
    return gulp.src('assets/img/*.*')
        .pipe(gulp.dest('wwwroot/assets/img'));
});
gulp.task("serve", gulp.parallel(["min", "copy-img"]));
gulp.task("default", gulp.series("serve"));
gulp.task('watch', function () { gulp.watch('assets/', gulp.series('serve')); });
