var gulp = require('gulp');

gulp.task('copy', function () {
    return gulp.src("/", {base:"."})
    .pipe(gulp.dest('../wwwroot/NetworkApp'));
});