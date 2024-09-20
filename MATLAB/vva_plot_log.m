function vva_plot_log(fn)

data = vva_read_log(fn);

figure;
subplot(211);
% plot(data.Time_s, data.Z);
% xlabel('Time (s)');
% ylabel('Roll Tilt (degrees)');
hold on;
plot(data.Time_s, data.X);

plot(data.Time_s, data.GazeAngX);
xlabel('Time (s)');
ylabel('X (m)');
