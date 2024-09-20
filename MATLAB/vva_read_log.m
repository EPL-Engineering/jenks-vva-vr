function [Data, Header] = vva_read_log(fn)

[h, dataString] = klib.file.parse_ini(fn, 'VVA DATA LOG');
Header = h.Info;

Data = klib.file.spreadsheet_string_to_struct(dataString);
Data.Time_s = Data.Time_s - Data.Time_s(1);
