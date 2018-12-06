﻿namespace AdventOfCode2018
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day3
    {
        private List<int>[,] _grid;

        public int SolveA()
        {
            var splittedInput = Helper.SplitInput(Input)
                .Select(x => new Claim(x))
                .ToList();

            var maxX = splittedInput.Max(c => c.X + c.Width);
            var maxY = splittedInput.Max(c => c.Y + c.Height);

            _grid = new List<int>[maxX, maxY];

            var overlappingSquare = 0;
            foreach (var claim in splittedInput)
            {
                for (int x = 0; x < claim.Width; x++)
                {
                    for (int y = 0; y < claim.Height; y++)
                    {
                        if (_grid[claim.X + x, claim.Y + y] == null) { _grid[claim.X + x, claim.Y + y] = new List<int>(); }

                        if (!_grid[claim.X + x, claim.Y + y].Contains(claim.Id))
                        {
                            _grid[claim.X + x, claim.Y + y].Add(claim.Id);
                        }

                        if (_grid[claim.X + x, claim.Y + y].Count == 2)
                        {
                            overlappingSquare++;
                        }
                    }
                }
            }

            return overlappingSquare;
        }

        public string SolveB()
        {
            // This generates a list with overlapping Ids
            // and the grid
            SolveA();

            var splittedInput = Helper.SplitInput(Input)
                .Select(x => new Claim(x))
                .Select(c => c.Id)
                .ToList();

            var overlappingIds = new List<int>();

            foreach (var item in _grid)
            {
                if (item != null && item.Count == 2)
                {
                    foreach (var i in item)
                    {
                        if (!overlappingIds.Contains(i)) { overlappingIds.Add(i); }
                    }
                }
            }

            var notOverlapping = splittedInput.Where(x => !overlappingIds.Contains(x));
            return string.Join(", ", notOverlapping);
        }

        private class Claim
        {
            public int Id { get; }
            public int X { get; }
            public int Y { get; }
            public int Width { get; }
            public int Height { get; }

            public Claim(string line)
            {
                var regex = new Regex(@"\#(\d+) \@ (\d+),(\d+): (\d+)x(\d+)");
                var match = regex.Match(line);

                Id = int.Parse(match.Groups[1].Value);
                X = int.Parse(match.Groups[2].Value);
                Y = int.Parse(match.Groups[3].Value);
                Width = int.Parse(match.Groups[4].Value);
                Height = int.Parse(match.Groups[5].Value);
            }
        }

        private const string SampleInput = "#1 @ 1,3: 4x4\r\n#2 @ 3,1: 4x4\r\n#3 @ 5,5: 2x2";

        private const string Input =
            "#1 @ 527,351: 24x10\r\n#2 @ 384,468: 27x21\r\n#3 @ 547,294: 19x13\r\n#4 @ 910,172: 19x18\r\n#5 @ 409,238: 25x10\r\n#6 @ 677,768: 28x15\r\n#7 @ 864,215: 15x23\r\n#8 @ 961,184: 13x24\r\n#9 @ 469,837: 27x24\r\n#10 @ 732,616: 10x21\r\n#11 @ 755,237: 24x22\r\n#12 @ 63,940: 17x18\r\n#13 @ 381,528: 27x18\r\n#14 @ 964,69: 28x20\r\n#15 @ 464,847: 10x22\r\n#16 @ 777,846: 24x17\r\n#17 @ 323,659: 26x12\r\n#18 @ 456,31: 22x6\r\n#19 @ 252,240: 14x18\r\n#20 @ 742,392: 19x17\r\n#21 @ 607,796: 24x19\r\n#22 @ 330,946: 23x15\r\n#23 @ 890,419: 29x20\r\n#24 @ 683,508: 15x14\r\n#25 @ 735,167: 10x3\r\n#26 @ 772,736: 28x27\r\n#27 @ 712,413: 6x3\r\n#28 @ 829,51: 29x26\r\n#29 @ 128,330: 29x22\r\n#30 @ 475,927: 12x14\r\n#31 @ 921,59: 24x28\r\n#32 @ 409,852: 29x16\r\n#33 @ 391,577: 23x22\r\n#34 @ 123,173: 20x13\r\n#35 @ 292,780: 25x27\r\n#36 @ 452,786: 27x29\r\n#37 @ 537,74: 28x27\r\n#38 @ 943,46: 27x18\r\n#39 @ 732,163: 19x13\r\n#40 @ 226,306: 18x24\r\n#41 @ 591,834: 13x15\r\n#42 @ 478,863: 23x13\r\n#43 @ 710,408: 16x24\r\n#44 @ 59,450: 20x17\r\n#45 @ 973,165: 17x18\r\n#46 @ 768,223: 26x27\r\n#47 @ 254,654: 24x13\r\n#48 @ 157,961: 19x29\r\n#49 @ 965,552: 19x19\r\n#50 @ 521,805: 11x19\r\n#51 @ 729,906: 19x27\r\n#52 @ 210,340: 17x17\r\n#53 @ 345,447: 27x22\r\n#54 @ 957,562: 11x29\r\n#55 @ 655,610: 23x12\r\n#56 @ 469,206: 17x15\r\n#57 @ 717,448: 28x24\r\n#58 @ 494,88: 29x17\r\n#59 @ 906,982: 26x11\r\n#60 @ 865,539: 23x27\r\n#61 @ 308,521: 27x20\r\n#62 @ 746,452: 20x14\r\n#63 @ 831,632: 19x20\r\n#64 @ 81,119: 13x22\r\n#65 @ 367,881: 10x28\r\n#66 @ 672,435: 12x16\r\n#67 @ 171,727: 21x20\r\n#68 @ 143,28: 12x23\r\n#69 @ 618,127: 23x26\r\n#70 @ 914,36: 16x19\r\n#71 @ 353,827: 11x24\r\n#72 @ 593,308: 18x20\r\n#73 @ 105,433: 19x27\r\n#74 @ 843,818: 27x25\r\n#75 @ 562,275: 24x20\r\n#76 @ 334,185: 29x29\r\n#77 @ 756,32: 24x17\r\n#78 @ 796,388: 18x25\r\n#79 @ 862,122: 10x28\r\n#80 @ 297,776: 16x22\r\n#81 @ 233,80: 25x20\r\n#82 @ 903,335: 25x12\r\n#83 @ 396,481: 15x15\r\n#84 @ 939,112: 13x13\r\n#85 @ 740,842: 12x16\r\n#86 @ 941,902: 19x25\r\n#87 @ 439,495: 13x25\r\n#88 @ 799,753: 21x19\r\n#89 @ 764,110: 29x15\r\n#90 @ 179,241: 13x15\r\n#91 @ 799,328: 19x26\r\n#92 @ 194,262: 14x29\r\n#93 @ 305,169: 20x26\r\n#94 @ 978,563: 20x24\r\n#95 @ 292,254: 7x15\r\n#96 @ 409,350: 16x18\r\n#97 @ 943,712: 10x22\r\n#98 @ 667,975: 27x15\r\n#99 @ 652,39: 24x23\r\n#100 @ 61,13: 15x24\r\n#101 @ 31,646: 16x28\r\n#102 @ 13,738: 18x14\r\n#103 @ 913,417: 26x17\r\n#104 @ 56,302: 14x28\r\n#105 @ 675,758: 23x13\r\n#106 @ 427,237: 21x20\r\n#107 @ 871,205: 19x25\r\n#108 @ 563,88: 25x25\r\n#109 @ 923,371: 17x12\r\n#110 @ 26,127: 13x27\r\n#111 @ 875,293: 28x15\r\n#112 @ 767,409: 14x21\r\n#113 @ 390,419: 28x25\r\n#114 @ 438,211: 20x10\r\n#115 @ 160,41: 20x21\r\n#116 @ 754,302: 21x19\r\n#117 @ 146,930: 21x13\r\n#118 @ 806,77: 10x24\r\n#119 @ 390,722: 15x16\r\n#120 @ 339,81: 16x18\r\n#121 @ 453,442: 16x17\r\n#122 @ 880,714: 28x26\r\n#123 @ 952,929: 29x25\r\n#124 @ 843,432: 14x11\r\n#125 @ 620,343: 29x22\r\n#126 @ 102,576: 26x16\r\n#127 @ 10,682: 13x16\r\n#128 @ 81,896: 18x10\r\n#129 @ 884,555: 15x26\r\n#130 @ 70,784: 10x12\r\n#131 @ 32,428: 19x13\r\n#132 @ 14,926: 14x20\r\n#133 @ 219,107: 18x13\r\n#134 @ 517,57: 29x28\r\n#135 @ 658,788: 11x27\r\n#136 @ 273,315: 10x15\r\n#137 @ 598,306: 10x11\r\n#138 @ 797,408: 12x25\r\n#139 @ 156,204: 7x10\r\n#140 @ 40,534: 25x23\r\n#141 @ 649,872: 16x16\r\n#142 @ 271,648: 25x19\r\n#143 @ 856,10: 10x11\r\n#144 @ 916,155: 26x17\r\n#145 @ 845,635: 20x16\r\n#146 @ 186,217: 20x15\r\n#147 @ 756,742: 19x22\r\n#148 @ 399,409: 14x22\r\n#149 @ 57,166: 20x20\r\n#150 @ 975,560: 20x15\r\n#151 @ 89,81: 12x11\r\n#152 @ 478,336: 22x11\r\n#153 @ 772,305: 15x24\r\n#154 @ 940,556: 22x10\r\n#155 @ 539,912: 16x24\r\n#156 @ 910,408: 14x23\r\n#157 @ 473,843: 14x29\r\n#158 @ 819,883: 15x16\r\n#159 @ 948,481: 29x17\r\n#160 @ 761,34: 10x12\r\n#161 @ 171,456: 10x14\r\n#162 @ 705,463: 18x16\r\n#163 @ 483,845: 26x20\r\n#164 @ 254,244: 6x9\r\n#165 @ 955,182: 28x29\r\n#166 @ 156,377: 17x20\r\n#167 @ 471,680: 26x24\r\n#168 @ 652,64: 14x19\r\n#169 @ 356,477: 14x19\r\n#170 @ 233,48: 14x13\r\n#171 @ 827,547: 25x14\r\n#172 @ 385,294: 15x17\r\n#173 @ 635,285: 15x12\r\n#174 @ 181,217: 10x24\r\n#175 @ 447,681: 12x14\r\n#176 @ 21,543: 16x12\r\n#177 @ 170,336: 20x26\r\n#178 @ 232,237: 20x14\r\n#179 @ 40,387: 19x12\r\n#180 @ 216,813: 15x25\r\n#181 @ 806,393: 10x23\r\n#182 @ 234,192: 28x13\r\n#183 @ 917,40: 6x16\r\n#184 @ 430,827: 18x20\r\n#185 @ 684,251: 25x10\r\n#186 @ 114,340: 12x15\r\n#187 @ 597,187: 20x16\r\n#188 @ 598,954: 19x10\r\n#189 @ 370,75: 28x25\r\n#190 @ 96,772: 29x27\r\n#191 @ 969,178: 11x28\r\n#192 @ 618,458: 22x16\r\n#193 @ 533,62: 26x23\r\n#194 @ 445,80: 24x27\r\n#195 @ 171,749: 23x25\r\n#196 @ 427,251: 23x25\r\n#197 @ 780,317: 18x22\r\n#198 @ 613,684: 18x16\r\n#199 @ 153,408: 12x13\r\n#200 @ 290,884: 4x12\r\n#201 @ 500,90: 29x23\r\n#202 @ 628,320: 27x19\r\n#203 @ 387,257: 10x17\r\n#204 @ 967,799: 19x16\r\n#205 @ 397,124: 10x20\r\n#206 @ 770,10: 26x22\r\n#207 @ 925,362: 28x19\r\n#208 @ 528,959: 22x20\r\n#209 @ 876,165: 19x20\r\n#210 @ 20,934: 11x15\r\n#211 @ 67,588: 20x12\r\n#212 @ 925,7: 15x12\r\n#213 @ 121,186: 26x10\r\n#214 @ 425,208: 21x13\r\n#215 @ 871,570: 12x29\r\n#216 @ 882,261: 11x29\r\n#217 @ 938,206: 27x17\r\n#218 @ 386,485: 10x28\r\n#219 @ 198,932: 11x19\r\n#220 @ 173,347: 20x26\r\n#221 @ 260,222: 19x19\r\n#222 @ 208,592: 23x12\r\n#223 @ 879,526: 21x16\r\n#224 @ 211,691: 20x13\r\n#225 @ 950,394: 11x23\r\n#226 @ 289,642: 15x17\r\n#227 @ 340,81: 16x27\r\n#228 @ 813,968: 23x19\r\n#229 @ 160,938: 20x12\r\n#230 @ 29,33: 19x17\r\n#231 @ 896,270: 18x25\r\n#232 @ 781,750: 21x18\r\n#233 @ 298,598: 11x10\r\n#234 @ 261,871: 15x27\r\n#235 @ 294,497: 22x25\r\n#236 @ 362,53: 15x20\r\n#237 @ 850,193: 22x20\r\n#238 @ 317,205: 28x15\r\n#239 @ 670,848: 18x12\r\n#240 @ 925,379: 19x23\r\n#241 @ 434,745: 16x18\r\n#242 @ 388,4: 12x12\r\n#243 @ 969,97: 22x20\r\n#244 @ 269,834: 27x24\r\n#245 @ 574,828: 21x23\r\n#246 @ 415,229: 26x18\r\n#247 @ 196,688: 29x21\r\n#248 @ 149,52: 20x11\r\n#249 @ 957,620: 24x22\r\n#250 @ 962,720: 13x24\r\n#251 @ 674,441: 20x28\r\n#252 @ 948,395: 24x28\r\n#253 @ 100,721: 20x23\r\n#254 @ 814,573: 12x19\r\n#255 @ 757,405: 10x20\r\n#256 @ 817,633: 19x16\r\n#257 @ 741,49: 18x18\r\n#258 @ 923,715: 21x23\r\n#259 @ 398,358: 12x25\r\n#260 @ 625,662: 23x28\r\n#261 @ 38,49: 13x22\r\n#262 @ 230,800: 22x23\r\n#263 @ 127,112: 15x28\r\n#264 @ 229,240: 27x12\r\n#265 @ 699,80: 22x26\r\n#266 @ 877,525: 21x13\r\n#267 @ 266,741: 17x21\r\n#268 @ 297,379: 11x13\r\n#269 @ 103,469: 15x24\r\n#270 @ 955,761: 19x24\r\n#271 @ 371,244: 27x23\r\n#272 @ 813,964: 18x23\r\n#273 @ 887,857: 21x29\r\n#274 @ 582,337: 19x20\r\n#275 @ 209,439: 25x14\r\n#276 @ 560,186: 14x18\r\n#277 @ 18,340: 23x13\r\n#278 @ 659,347: 21x22\r\n#279 @ 923,928: 29x16\r\n#280 @ 776,916: 14x24\r\n#281 @ 296,143: 13x13\r\n#282 @ 26,912: 23x18\r\n#283 @ 980,326: 15x13\r\n#284 @ 628,910: 12x21\r\n#285 @ 454,356: 21x18\r\n#286 @ 74,368: 13x22\r\n#287 @ 6,657: 28x17\r\n#288 @ 595,719: 20x29\r\n#289 @ 934,75: 23x23\r\n#290 @ 618,337: 24x13\r\n#291 @ 777,632: 17x11\r\n#292 @ 247,164: 29x21\r\n#293 @ 625,920: 14x27\r\n#294 @ 0,376: 25x25\r\n#295 @ 252,176: 25x17\r\n#296 @ 772,262: 28x17\r\n#297 @ 264,385: 18x14\r\n#298 @ 181,819: 21x24\r\n#299 @ 326,192: 17x18\r\n#300 @ 392,611: 15x29\r\n#301 @ 625,815: 10x10\r\n#302 @ 191,760: 20x14\r\n#303 @ 398,582: 24x26\r\n#304 @ 328,837: 28x12\r\n#305 @ 728,617: 23x11\r\n#306 @ 835,357: 15x10\r\n#307 @ 69,941: 15x10\r\n#308 @ 811,957: 21x15\r\n#309 @ 92,796: 12x20\r\n#310 @ 652,972: 14x12\r\n#311 @ 133,766: 21x20\r\n#312 @ 550,169: 24x23\r\n#313 @ 515,985: 22x11\r\n#314 @ 980,12: 10x15\r\n#315 @ 754,945: 26x18\r\n#316 @ 855,418: 10x28\r\n#317 @ 971,846: 20x22\r\n#318 @ 6,135: 20x10\r\n#319 @ 449,751: 12x18\r\n#320 @ 704,428: 26x16\r\n#321 @ 571,210: 27x15\r\n#322 @ 498,4: 10x13\r\n#323 @ 745,299: 22x13\r\n#324 @ 341,852: 19x13\r\n#325 @ 26,663: 28x18\r\n#326 @ 864,42: 20x15\r\n#327 @ 135,148: 24x28\r\n#328 @ 256,215: 12x28\r\n#329 @ 467,499: 22x11\r\n#330 @ 836,259: 12x11\r\n#331 @ 46,879: 27x22\r\n#332 @ 498,950: 27x25\r\n#333 @ 973,645: 23x24\r\n#334 @ 752,417: 5x5\r\n#335 @ 136,97: 12x20\r\n#336 @ 660,170: 14x19\r\n#337 @ 351,819: 19x26\r\n#338 @ 556,363: 29x29\r\n#339 @ 566,381: 13x23\r\n#340 @ 780,721: 28x10\r\n#341 @ 799,945: 13x29\r\n#342 @ 874,135: 20x14\r\n#343 @ 47,158: 16x10\r\n#344 @ 426,611: 12x21\r\n#345 @ 864,334: 26x24\r\n#346 @ 356,905: 27x10\r\n#347 @ 503,522: 13x21\r\n#348 @ 187,965: 22x11\r\n#349 @ 591,774: 11x19\r\n#350 @ 764,192: 15x13\r\n#351 @ 935,563: 18x26\r\n#352 @ 772,413: 20x19\r\n#353 @ 975,365: 18x29\r\n#354 @ 355,652: 13x29\r\n#355 @ 665,35: 14x19\r\n#356 @ 291,136: 27x26\r\n#357 @ 335,341: 20x13\r\n#358 @ 26,146: 25x25\r\n#359 @ 305,593: 19x20\r\n#360 @ 330,702: 19x15\r\n#361 @ 589,605: 21x13\r\n#362 @ 250,867: 29x12\r\n#363 @ 854,124: 27x13\r\n#364 @ 266,582: 20x12\r\n#365 @ 520,445: 15x18\r\n#366 @ 11,744: 12x17\r\n#367 @ 92,624: 28x14\r\n#368 @ 181,307: 24x29\r\n#369 @ 397,815: 23x28\r\n#370 @ 319,51: 20x11\r\n#371 @ 922,705: 11x21\r\n#372 @ 300,755: 19x14\r\n#373 @ 331,987: 17x8\r\n#374 @ 832,634: 20x12\r\n#375 @ 576,38: 17x25\r\n#376 @ 923,402: 22x11\r\n#377 @ 544,898: 24x21\r\n#378 @ 369,15: 21x24\r\n#379 @ 141,130: 10x28\r\n#380 @ 711,333: 22x26\r\n#381 @ 390,881: 29x13\r\n#382 @ 975,0: 14x17\r\n#383 @ 863,703: 22x21\r\n#384 @ 68,658: 28x15\r\n#385 @ 934,919: 21x27\r\n#386 @ 941,476: 15x18\r\n#387 @ 547,12: 13x22\r\n#388 @ 455,440: 26x21\r\n#389 @ 443,348: 24x20\r\n#390 @ 663,137: 12x10\r\n#391 @ 239,727: 22x13\r\n#392 @ 465,762: 10x13\r\n#393 @ 142,7: 24x22\r\n#394 @ 519,829: 10x28\r\n#395 @ 851,784: 25x21\r\n#396 @ 515,319: 16x10\r\n#397 @ 74,437: 18x21\r\n#398 @ 117,123: 19x27\r\n#399 @ 220,354: 25x27\r\n#400 @ 797,320: 25x20\r\n#401 @ 437,711: 19x21\r\n#402 @ 860,780: 19x23\r\n#403 @ 273,920: 13x20\r\n#404 @ 658,34: 15x12\r\n#405 @ 890,17: 21x19\r\n#406 @ 836,120: 23x19\r\n#407 @ 896,300: 28x12\r\n#408 @ 969,247: 11x25\r\n#409 @ 185,238: 10x23\r\n#410 @ 895,5: 14x26\r\n#411 @ 971,948: 22x12\r\n#412 @ 960,77: 11x14\r\n#413 @ 461,93: 11x26\r\n#414 @ 757,448: 15x10\r\n#415 @ 714,411: 29x11\r\n#416 @ 847,205: 4x7\r\n#417 @ 972,625: 17x27\r\n#418 @ 749,64: 17x24\r\n#419 @ 732,397: 29x13\r\n#420 @ 329,579: 18x12\r\n#421 @ 25,208: 23x10\r\n#422 @ 689,205: 17x19\r\n#423 @ 698,553: 25x23\r\n#424 @ 267,258: 14x18\r\n#425 @ 634,182: 17x18\r\n#426 @ 203,51: 14x21\r\n#427 @ 643,829: 26x22\r\n#428 @ 791,959: 29x29\r\n#429 @ 934,3: 28x10\r\n#430 @ 239,748: 20x14\r\n#431 @ 210,767: 25x16\r\n#432 @ 207,932: 20x14\r\n#433 @ 811,93: 22x21\r\n#434 @ 628,425: 18x27\r\n#435 @ 591,716: 19x12\r\n#436 @ 856,42: 19x12\r\n#437 @ 635,313: 24x26\r\n#438 @ 626,186: 11x12\r\n#439 @ 438,712: 22x27\r\n#440 @ 111,736: 21x10\r\n#441 @ 332,452: 20x10\r\n#442 @ 202,426: 21x17\r\n#443 @ 445,613: 28x21\r\n#444 @ 169,741: 20x16\r\n#445 @ 807,114: 29x24\r\n#446 @ 208,649: 17x19\r\n#447 @ 627,593: 25x10\r\n#448 @ 28,815: 20x25\r\n#449 @ 354,701: 7x10\r\n#450 @ 970,852: 13x20\r\n#451 @ 348,99: 11x21\r\n#452 @ 449,840: 21x29\r\n#453 @ 437,706: 24x23\r\n#454 @ 742,100: 12x29\r\n#455 @ 481,166: 12x11\r\n#456 @ 332,392: 13x28\r\n#457 @ 557,718: 24x20\r\n#458 @ 819,876: 25x16\r\n#459 @ 975,324: 15x26\r\n#460 @ 26,202: 10x19\r\n#461 @ 862,76: 13x23\r\n#462 @ 792,47: 19x17\r\n#463 @ 511,305: 16x13\r\n#464 @ 794,596: 25x25\r\n#465 @ 745,556: 17x17\r\n#466 @ 227,705: 20x13\r\n#467 @ 221,87: 13x14\r\n#468 @ 922,771: 27x24\r\n#469 @ 861,720: 29x10\r\n#470 @ 729,521: 23x16\r\n#471 @ 485,495: 10x21\r\n#472 @ 26,736: 29x15\r\n#473 @ 453,26: 29x20\r\n#474 @ 361,87: 28x24\r\n#475 @ 199,667: 28x15\r\n#476 @ 47,217: 28x24\r\n#477 @ 967,538: 15x15\r\n#478 @ 725,115: 20x23\r\n#479 @ 494,900: 15x11\r\n#480 @ 320,625: 20x15\r\n#481 @ 690,511: 13x10\r\n#482 @ 430,391: 12x17\r\n#483 @ 949,467: 27x23\r\n#484 @ 857,50: 11x19\r\n#485 @ 502,480: 22x18\r\n#486 @ 64,170: 28x25\r\n#487 @ 971,542: 7x4\r\n#488 @ 917,337: 12x15\r\n#489 @ 0,877: 11x12\r\n#490 @ 453,62: 24x28\r\n#491 @ 861,544: 15x15\r\n#492 @ 750,751: 22x11\r\n#493 @ 939,382: 24x21\r\n#494 @ 761,188: 10x27\r\n#495 @ 168,467: 21x19\r\n#496 @ 743,937: 18x10\r\n#497 @ 790,118: 14x22\r\n#498 @ 760,384: 24x29\r\n#499 @ 83,367: 29x20\r\n#500 @ 89,672: 22x21\r\n#501 @ 354,184: 20x19\r\n#502 @ 206,204: 13x20\r\n#503 @ 338,563: 14x28\r\n#504 @ 918,167: 26x18\r\n#505 @ 631,788: 28x13\r\n#506 @ 89,332: 7x15\r\n#507 @ 441,390: 18x14\r\n#508 @ 305,961: 26x10\r\n#509 @ 637,722: 24x16\r\n#510 @ 543,851: 15x10\r\n#511 @ 387,604: 10x24\r\n#512 @ 410,950: 19x25\r\n#513 @ 750,306: 24x29\r\n#514 @ 422,473: 24x26\r\n#515 @ 947,731: 20x12\r\n#516 @ 328,420: 25x27\r\n#517 @ 488,893: 17x20\r\n#518 @ 462,777: 19x21\r\n#519 @ 234,682: 15x20\r\n#520 @ 867,12: 15x19\r\n#521 @ 434,879: 14x23\r\n#522 @ 671,347: 18x19\r\n#523 @ 770,299: 23x24\r\n#524 @ 193,753: 25x13\r\n#525 @ 321,754: 11x12\r\n#526 @ 402,560: 19x18\r\n#527 @ 430,688: 25x26\r\n#528 @ 42,374: 14x18\r\n#529 @ 186,927: 20x19\r\n#530 @ 477,497: 15x23\r\n#531 @ 516,777: 25x23\r\n#532 @ 65,113: 24x21\r\n#533 @ 291,167: 15x29\r\n#534 @ 898,461: 27x16\r\n#535 @ 337,106: 17x20\r\n#536 @ 336,344: 10x22\r\n#537 @ 137,706: 29x18\r\n#538 @ 552,704: 17x18\r\n#539 @ 144,821: 29x13\r\n#540 @ 213,106: 21x21\r\n#541 @ 482,193: 17x22\r\n#542 @ 329,984: 29x15\r\n#543 @ 28,264: 21x29\r\n#544 @ 960,431: 14x23\r\n#545 @ 196,674: 16x21\r\n#546 @ 310,31: 19x25\r\n#547 @ 98,344: 25x15\r\n#548 @ 762,103: 11x16\r\n#549 @ 315,723: 11x13\r\n#550 @ 872,9: 16x25\r\n#551 @ 172,289: 26x19\r\n#552 @ 341,471: 10x11\r\n#553 @ 500,630: 22x25\r\n#554 @ 405,701: 26x27\r\n#555 @ 480,339: 11x4\r\n#556 @ 736,251: 27x24\r\n#557 @ 948,275: 12x18\r\n#558 @ 823,578: 26x20\r\n#559 @ 503,0: 14x19\r\n#560 @ 336,533: 28x13\r\n#561 @ 498,736: 28x28\r\n#562 @ 749,210: 26x27\r\n#563 @ 810,40: 21x20\r\n#564 @ 283,282: 12x24\r\n#565 @ 498,33: 14x12\r\n#566 @ 594,490: 26x20\r\n#567 @ 764,783: 19x11\r\n#568 @ 219,329: 27x16\r\n#569 @ 445,492: 16x12\r\n#570 @ 578,788: 16x18\r\n#571 @ 323,826: 21x13\r\n#572 @ 65,222: 22x18\r\n#573 @ 642,750: 19x20\r\n#574 @ 933,387: 22x19\r\n#575 @ 144,322: 25x13\r\n#576 @ 173,923: 14x24\r\n#577 @ 637,45: 26x14\r\n#578 @ 21,559: 23x28\r\n#579 @ 646,880: 10x26\r\n#580 @ 495,899: 23x29\r\n#581 @ 416,842: 23x20\r\n#582 @ 621,121: 13x19\r\n#583 @ 978,239: 17x27\r\n#584 @ 724,627: 21x13\r\n#585 @ 503,751: 18x5\r\n#586 @ 559,84: 14x15\r\n#587 @ 904,786: 22x26\r\n#588 @ 62,691: 12x25\r\n#589 @ 50,499: 14x22\r\n#590 @ 474,367: 26x18\r\n#591 @ 290,508: 17x16\r\n#592 @ 274,895: 12x26\r\n#593 @ 654,734: 16x19\r\n#594 @ 131,167: 29x16\r\n#595 @ 818,739: 19x23\r\n#596 @ 586,269: 19x17\r\n#597 @ 690,760: 28x25\r\n#598 @ 214,691: 15x18\r\n#599 @ 858,30: 14x18\r\n#600 @ 357,202: 21x23\r\n#601 @ 452,2: 23x29\r\n#602 @ 978,663: 12x12\r\n#603 @ 362,853: 23x12\r\n#604 @ 288,299: 14x14\r\n#605 @ 680,750: 15x10\r\n#606 @ 906,953: 19x17\r\n#607 @ 369,496: 11x18\r\n#608 @ 555,827: 19x28\r\n#609 @ 614,95: 15x18\r\n#610 @ 227,755: 20x21\r\n#611 @ 942,548: 28x10\r\n#612 @ 908,314: 17x28\r\n#613 @ 643,0: 12x22\r\n#614 @ 26,668: 11x11\r\n#615 @ 124,50: 10x21\r\n#616 @ 465,174: 23x18\r\n#617 @ 22,197: 26x23\r\n#618 @ 711,854: 17x29\r\n#619 @ 266,541: 23x14\r\n#620 @ 300,872: 19x22\r\n#621 @ 977,101: 18x22\r\n#622 @ 523,960: 15x29\r\n#623 @ 387,90: 11x18\r\n#624 @ 262,264: 15x25\r\n#625 @ 177,155: 29x12\r\n#626 @ 132,161: 23x26\r\n#627 @ 46,769: 24x19\r\n#628 @ 840,51: 15x18\r\n#629 @ 273,401: 23x25\r\n#630 @ 392,580: 18x25\r\n#631 @ 74,380: 6x6\r\n#632 @ 709,25: 11x16\r\n#633 @ 223,201: 14x28\r\n#634 @ 25,115: 12x28\r\n#635 @ 36,351: 22x26\r\n#636 @ 540,596: 10x20\r\n#637 @ 703,772: 29x22\r\n#638 @ 51,668: 23x26\r\n#639 @ 181,212: 28x11\r\n#640 @ 376,2: 28x24\r\n#641 @ 654,34: 29x12\r\n#642 @ 792,716: 18x27\r\n#643 @ 390,634: 16x14\r\n#644 @ 303,945: 21x22\r\n#645 @ 754,123: 17x11\r\n#646 @ 565,594: 19x16\r\n#647 @ 699,871: 20x23\r\n#648 @ 363,74: 12x24\r\n#649 @ 275,388: 22x25\r\n#650 @ 776,557: 26x20\r\n#651 @ 683,847: 12x21\r\n#652 @ 599,848: 22x10\r\n#653 @ 78,599: 24x21\r\n#654 @ 123,565: 29x16\r\n#655 @ 232,712: 24x20\r\n#656 @ 392,862: 11x27\r\n#657 @ 199,104: 24x18\r\n#658 @ 36,609: 20x24\r\n#659 @ 755,478: 23x16\r\n#660 @ 136,772: 13x10\r\n#661 @ 13,977: 28x16\r\n#662 @ 575,423: 14x21\r\n#663 @ 720,586: 26x11\r\n#664 @ 948,907: 8x12\r\n#665 @ 221,730: 27x20\r\n#666 @ 28,352: 26x11\r\n#667 @ 129,777: 24x18\r\n#668 @ 454,857: 25x23\r\n#669 @ 53,457: 12x13\r\n#670 @ 607,558: 25x10\r\n#671 @ 71,839: 10x26\r\n#672 @ 174,755: 12x20\r\n#673 @ 290,251: 12x24\r\n#674 @ 142,351: 21x22\r\n#675 @ 476,376: 29x10\r\n#676 @ 972,770: 27x28\r\n#677 @ 488,214: 26x14\r\n#678 @ 87,785: 15x18\r\n#679 @ 638,11: 19x28\r\n#680 @ 896,977: 11x16\r\n#681 @ 96,948: 27x24\r\n#682 @ 135,371: 10x23\r\n#683 @ 815,113: 24x24\r\n#684 @ 263,820: 25x19\r\n#685 @ 943,140: 29x23\r\n#686 @ 546,30: 12x15\r\n#687 @ 278,379: 11x26\r\n#688 @ 239,494: 27x17\r\n#689 @ 43,542: 15x4\r\n#690 @ 847,84: 21x10\r\n#691 @ 54,681: 24x16\r\n#692 @ 665,121: 19x26\r\n#693 @ 473,90: 12x10\r\n#694 @ 284,224: 29x24\r\n#695 @ 271,969: 22x13\r\n#696 @ 893,324: 14x14\r\n#697 @ 892,510: 10x17\r\n#698 @ 827,808: 16x20\r\n#699 @ 559,53: 18x24\r\n#700 @ 839,105: 29x29\r\n#701 @ 691,970: 20x16\r\n#702 @ 821,736: 16x10\r\n#703 @ 583,212: 29x22\r\n#704 @ 348,850: 11x25\r\n#705 @ 180,520: 14x22\r\n#706 @ 824,92: 26x29\r\n#707 @ 632,174: 10x27\r\n#708 @ 822,95: 29x19\r\n#709 @ 940,563: 11x16\r\n#710 @ 825,837: 27x28\r\n#711 @ 601,429: 18x15\r\n#712 @ 700,453: 17x15\r\n#713 @ 901,96: 24x14\r\n#714 @ 617,62: 23x11\r\n#715 @ 738,575: 15x17\r\n#716 @ 605,593: 27x15\r\n#717 @ 802,865: 25x14\r\n#718 @ 564,594: 13x17\r\n#719 @ 33,52: 12x14\r\n#720 @ 112,152: 13x11\r\n#721 @ 757,392: 20x28\r\n#722 @ 520,317: 10x10\r\n#723 @ 746,9: 11x23\r\n#724 @ 291,53: 21x14\r\n#725 @ 554,93: 17x27\r\n#726 @ 596,172: 15x28\r\n#727 @ 441,878: 13x14\r\n#728 @ 802,424: 28x14\r\n#729 @ 293,188: 23x29\r\n#730 @ 539,108: 22x15\r\n#731 @ 296,293: 20x25\r\n#732 @ 290,523: 27x26\r\n#733 @ 700,852: 16x26\r\n#734 @ 919,478: 23x21\r\n#735 @ 664,850: 15x13\r\n#736 @ 72,612: 27x27\r\n#737 @ 872,73: 15x23\r\n#738 @ 891,7: 21x10\r\n#739 @ 754,381: 21x15\r\n#740 @ 670,38: 27x16\r\n#741 @ 269,327: 24x22\r\n#742 @ 735,619: 24x21\r\n#743 @ 632,338: 27x12\r\n#744 @ 178,346: 14x28\r\n#745 @ 656,599: 20x12\r\n#746 @ 94,494: 20x15\r\n#747 @ 393,960: 13x16\r\n#748 @ 887,265: 18x13\r\n#749 @ 362,337: 10x28\r\n#750 @ 890,192: 24x28\r\n#751 @ 599,973: 13x17\r\n#752 @ 61,316: 25x28\r\n#753 @ 647,28: 19x24\r\n#754 @ 194,649: 29x24\r\n#755 @ 43,36: 24x18\r\n#756 @ 147,396: 29x16\r\n#757 @ 70,372: 19x25\r\n#758 @ 305,758: 13x10\r\n#759 @ 281,165: 11x21\r\n#760 @ 317,838: 15x14\r\n#761 @ 216,333: 29x14\r\n#762 @ 19,984: 12x13\r\n#763 @ 17,894: 26x12\r\n#764 @ 174,386: 12x27\r\n#765 @ 180,743: 15x10\r\n#766 @ 75,855: 15x21\r\n#767 @ 946,533: 29x23\r\n#768 @ 477,511: 17x22\r\n#769 @ 519,480: 23x12\r\n#770 @ 775,272: 21x25\r\n#771 @ 510,332: 28x24\r\n#772 @ 900,26: 24x12\r\n#773 @ 605,343: 29x23\r\n#774 @ 216,860: 29x26\r\n#775 @ 200,263: 15x17\r\n#776 @ 343,313: 17x10\r\n#777 @ 407,472: 13x11\r\n#778 @ 780,175: 14x22\r\n#779 @ 852,214: 21x20\r\n#780 @ 477,699: 24x17\r\n#781 @ 593,598: 24x25\r\n#782 @ 798,308: 27x28\r\n#783 @ 740,38: 11x13\r\n#784 @ 222,492: 27x24\r\n#785 @ 740,757: 11x25\r\n#786 @ 635,850: 23x12\r\n#787 @ 295,17: 29x27\r\n#788 @ 297,388: 14x11\r\n#789 @ 753,78: 27x29\r\n#790 @ 216,681: 12x27\r\n#791 @ 273,530: 14x26\r\n#792 @ 815,40: 27x19\r\n#793 @ 869,594: 17x22\r\n#794 @ 265,972: 22x18\r\n#795 @ 904,568: 21x16\r\n#796 @ 824,386: 28x23\r\n#797 @ 727,448: 19x25\r\n#798 @ 516,639: 14x14\r\n#799 @ 287,365: 19x29\r\n#800 @ 701,889: 12x13\r\n#801 @ 25,896: 8x6\r\n#802 @ 321,624: 12x14\r\n#803 @ 600,282: 16x16\r\n#804 @ 952,399: 10x17\r\n#805 @ 41,609: 29x13\r\n#806 @ 489,605: 14x29\r\n#807 @ 361,493: 18x12\r\n#808 @ 316,357: 12x28\r\n#809 @ 714,401: 10x11\r\n#810 @ 194,927: 26x20\r\n#811 @ 952,280: 10x17\r\n#812 @ 960,208: 22x29\r\n#813 @ 744,225: 17x20\r\n#814 @ 787,931: 18x24\r\n#815 @ 863,939: 23x20\r\n#816 @ 548,201: 15x23\r\n#817 @ 262,362: 22x25\r\n#818 @ 297,651: 16x14\r\n#819 @ 454,753: 24x27\r\n#820 @ 772,900: 17x18\r\n#821 @ 375,737: 17x23\r\n#822 @ 209,216: 23x29\r\n#823 @ 487,280: 18x15\r\n#824 @ 847,71: 12x23\r\n#825 @ 808,688: 15x29\r\n#826 @ 593,599: 18x13\r\n#827 @ 633,977: 28x10\r\n#828 @ 585,277: 13x16\r\n#829 @ 632,722: 18x11\r\n#830 @ 320,931: 25x21\r\n#831 @ 866,693: 18x14\r\n#832 @ 136,797: 26x29\r\n#833 @ 249,705: 12x5\r\n#834 @ 851,460: 23x27\r\n#835 @ 114,148: 21x13\r\n#836 @ 970,756: 29x17\r\n#837 @ 213,434: 28x23\r\n#838 @ 105,505: 28x11\r\n#839 @ 334,666: 13x13\r\n#840 @ 162,208: 23x17\r\n#841 @ 671,397: 17x25\r\n#842 @ 729,47: 28x20\r\n#843 @ 959,868: 18x28\r\n#844 @ 69,829: 17x23\r\n#845 @ 473,795: 11x14\r\n#846 @ 359,637: 29x12\r\n#847 @ 349,205: 10x12\r\n#848 @ 430,488: 18x18\r\n#849 @ 924,35: 16x18\r\n#850 @ 712,27: 4x10\r\n#851 @ 894,278: 13x26\r\n#852 @ 66,321: 16x6\r\n#853 @ 311,375: 13x20\r\n#854 @ 821,803: 11x17\r\n#855 @ 28,147: 22x20\r\n#856 @ 165,932: 20x18\r\n#857 @ 254,895: 12x10\r\n#858 @ 307,837: 28x29\r\n#859 @ 705,206: 18x18\r\n#860 @ 102,283: 26x25\r\n#861 @ 444,620: 14x24\r\n#862 @ 652,758: 12x17\r\n#863 @ 210,334: 14x27\r\n#864 @ 948,557: 24x11\r\n#865 @ 51,708: 17x14\r\n#866 @ 190,475: 29x17\r\n#867 @ 665,778: 13x17\r\n#868 @ 337,475: 25x26\r\n#869 @ 533,521: 23x14\r\n#870 @ 35,347: 29x23\r\n#871 @ 109,342: 23x14\r\n#872 @ 892,869: 28x26\r\n#873 @ 325,944: 10x26\r\n#874 @ 22,195: 14x26\r\n#875 @ 46,714: 24x11\r\n#876 @ 617,337: 12x25\r\n#877 @ 98,950: 22x19\r\n#878 @ 823,492: 13x29\r\n#879 @ 853,264: 10x18\r\n#880 @ 410,843: 28x29\r\n#881 @ 207,654: 14x22\r\n#882 @ 736,22: 18x15\r\n#883 @ 173,963: 29x12\r\n#884 @ 5,878: 27x13\r\n#885 @ 906,949: 17x27\r\n#886 @ 868,82: 14x16\r\n#887 @ 517,967: 13x20\r\n#888 @ 606,958: 26x16\r\n#889 @ 206,691: 15x21\r\n#890 @ 254,909: 21x13\r\n#891 @ 428,123: 20x10\r\n#892 @ 547,100: 10x26\r\n#893 @ 67,452: 29x15\r\n#894 @ 833,811: 18x26\r\n#895 @ 561,636: 24x13\r\n#896 @ 701,748: 28x20\r\n#897 @ 766,432: 24x15\r\n#898 @ 869,31: 16x14\r\n#899 @ 935,471: 19x19\r\n#900 @ 343,465: 15x11\r\n#901 @ 630,458: 29x12\r\n#902 @ 30,919: 6x5\r\n#903 @ 494,40: 17x18\r\n#904 @ 599,671: 23x13\r\n#905 @ 506,103: 20x17\r\n#906 @ 104,56: 23x11\r\n#907 @ 110,154: 13x15\r\n#908 @ 508,36: 17x18\r\n#909 @ 24,128: 15x21\r\n#910 @ 214,676: 16x27\r\n#911 @ 265,894: 18x24\r\n#912 @ 158,226: 29x19\r\n#913 @ 79,505: 27x25\r\n#914 @ 4,670: 11x16\r\n#915 @ 912,838: 27x25\r\n#916 @ 277,352: 16x22\r\n#917 @ 661,399: 11x22\r\n#918 @ 410,461: 20x24\r\n#919 @ 261,220: 27x18\r\n#920 @ 396,116: 10x13\r\n#921 @ 313,839: 24x12\r\n#922 @ 784,329: 5x11\r\n#923 @ 217,475: 29x23\r\n#924 @ 938,56: 11x10\r\n#925 @ 468,86: 26x14\r\n#926 @ 920,396: 26x18\r\n#927 @ 895,469: 10x11\r\n#928 @ 821,483: 11x24\r\n#929 @ 862,663: 19x10\r\n#930 @ 904,93: 18x20\r\n#931 @ 195,803: 22x22\r\n#932 @ 40,327: 27x19\r\n#933 @ 16,47: 18x19\r\n#934 @ 344,854: 12x8\r\n#935 @ 551,510: 18x12\r\n#936 @ 100,299: 19x26\r\n#937 @ 195,426: 11x17\r\n#938 @ 541,379: 18x23\r\n#939 @ 759,712: 10x25\r\n#940 @ 708,858: 4x13\r\n#941 @ 30,937: 24x10\r\n#942 @ 346,318: 11x16\r\n#943 @ 452,667: 11x21\r\n#944 @ 477,202: 10x15\r\n#945 @ 16,747: 13x15\r\n#946 @ 15,55: 10x10\r\n#947 @ 718,907: 25x25\r\n#948 @ 790,128: 22x23\r\n#949 @ 226,692: 27x22\r\n#950 @ 322,759: 11x18\r\n#951 @ 458,918: 26x12\r\n#952 @ 308,34: 11x18\r\n#953 @ 523,802: 26x26\r\n#954 @ 549,107: 4x13\r\n#955 @ 909,597: 21x29\r\n#956 @ 332,488: 12x16\r\n#957 @ 937,897: 27x26\r\n#958 @ 905,971: 10x28\r\n#959 @ 558,643: 23x29\r\n#960 @ 590,961: 10x28\r\n#961 @ 830,264: 16x12\r\n#962 @ 773,323: 27x28\r\n#963 @ 941,85: 9x9\r\n#964 @ 753,477: 12x25\r\n#965 @ 905,402: 25x13\r\n#966 @ 877,51: 27x10\r\n#967 @ 149,706: 20x11\r\n#968 @ 162,517: 29x28\r\n#969 @ 634,755: 22x16\r\n#970 @ 80,809: 26x27\r\n#971 @ 22,384: 15x10\r\n#972 @ 882,659: 21x28\r\n#973 @ 23,131: 28x27\r\n#974 @ 205,529: 16x18\r\n#975 @ 512,822: 28x21\r\n#976 @ 278,412: 28x22\r\n#977 @ 508,627: 29x10\r\n#978 @ 569,74: 25x15\r\n#979 @ 495,610: 17x14\r\n#980 @ 659,334: 10x26\r\n#981 @ 980,801: 14x23\r\n#982 @ 851,408: 12x14\r\n#983 @ 726,871: 27x19\r\n#984 @ 175,972: 20x12\r\n#985 @ 97,578: 11x15\r\n#986 @ 75,265: 18x22\r\n#987 @ 737,838: 12x10\r\n#988 @ 976,569: 21x11\r\n#989 @ 255,584: 28x12\r\n#990 @ 963,919: 14x22\r\n#991 @ 369,65: 21x29\r\n#992 @ 916,563: 23x13\r\n#993 @ 208,376: 29x24\r\n#994 @ 85,268: 16x12\r\n#995 @ 300,424: 18x20\r\n#996 @ 581,295: 20x27\r\n#997 @ 827,840: 21x20\r\n#998 @ 580,436: 20x15\r\n#999 @ 341,405: 10x18\r\n#1000 @ 560,78: 10x11\r\n#1001 @ 120,4: 29x26\r\n#1002 @ 543,607: 15x15\r\n#1003 @ 1,845: 10x14\r\n#1004 @ 257,731: 21x21\r\n#1005 @ 70,779: 12x10\r\n#1006 @ 21,565: 10x20\r\n#1007 @ 175,207: 11x19\r\n#1008 @ 350,853: 6x14\r\n#1009 @ 824,545: 12x13\r\n#1010 @ 431,64: 28x28\r\n#1011 @ 451,677: 10x10\r\n#1012 @ 445,678: 17x23\r\n#1013 @ 73,193: 10x14\r\n#1014 @ 650,794: 23x16\r\n#1015 @ 264,966: 17x28\r\n#1016 @ 320,425: 27x23\r\n#1017 @ 74,695: 16x21\r\n#1018 @ 340,944: 28x10\r\n#1019 @ 333,469: 24x29\r\n#1020 @ 686,542: 22x28\r\n#1021 @ 496,39: 21x21\r\n#1022 @ 869,923: 14x21\r\n#1023 @ 871,907: 26x25\r\n#1024 @ 84,330: 21x21\r\n#1025 @ 329,714: 24x22\r\n#1026 @ 813,474: 15x25\r\n#1027 @ 761,550: 23x25\r\n#1028 @ 698,352: 28x11\r\n#1029 @ 531,16: 19x10\r\n#1030 @ 312,503: 19x25\r\n#1031 @ 297,302: 20x24\r\n#1032 @ 476,801: 13x22\r\n#1033 @ 350,539: 16x11\r\n#1034 @ 480,788: 16x17\r\n#1035 @ 316,881: 13x18\r\n#1036 @ 975,365: 19x28\r\n#1037 @ 84,89: 19x17\r\n#1038 @ 616,542: 10x24\r\n#1039 @ 931,532: 27x26\r\n#1040 @ 601,673: 17x7\r\n#1041 @ 874,135: 26x17\r\n#1042 @ 532,180: 23x16\r\n#1043 @ 476,2: 29x18\r\n#1044 @ 97,435: 18x25\r\n#1045 @ 812,812: 5x10\r\n#1046 @ 865,63: 17x20\r\n#1047 @ 913,158: 21x15\r\n#1048 @ 78,412: 16x23\r\n#1049 @ 864,137: 13x11\r\n#1050 @ 385,637: 24x19\r\n#1051 @ 122,494: 15x28\r\n#1052 @ 942,101: 29x21\r\n#1053 @ 288,153: 27x15\r\n#1054 @ 802,898: 23x17\r\n#1055 @ 447,182: 24x10\r\n#1056 @ 598,599: 10x22\r\n#1057 @ 622,812: 13x18\r\n#1058 @ 685,850: 6x14\r\n#1059 @ 656,523: 22x25\r\n#1060 @ 904,109: 25x12\r\n#1061 @ 28,139: 7x11\r\n#1062 @ 23,809: 25x20\r\n#1063 @ 391,954: 12x17\r\n#1064 @ 474,19: 14x22\r\n#1065 @ 204,579: 20x23\r\n#1066 @ 314,863: 22x25\r\n#1067 @ 573,235: 16x14\r\n#1068 @ 520,446: 15x12\r\n#1069 @ 355,662: 17x19\r\n#1070 @ 70,408: 27x26\r\n#1071 @ 769,519: 18x17\r\n#1072 @ 554,905: 4x5\r\n#1073 @ 948,834: 29x13\r\n#1074 @ 276,856: 21x24\r\n#1075 @ 975,453: 17x24\r\n#1076 @ 735,723: 27x15\r\n#1077 @ 82,397: 20x18\r\n#1078 @ 162,500: 14x28\r\n#1079 @ 411,88: 12x24\r\n#1080 @ 830,703: 22x25\r\n#1081 @ 227,862: 23x11\r\n#1082 @ 523,78: 15x26\r\n#1083 @ 363,876: 13x29\r\n#1084 @ 741,767: 26x28\r\n#1085 @ 934,379: 13x29\r\n#1086 @ 13,541: 27x27\r\n#1087 @ 738,521: 10x13\r\n#1088 @ 253,967: 16x12\r\n#1089 @ 440,729: 15x24\r\n#1090 @ 245,491: 22x14\r\n#1091 @ 405,69: 18x21\r\n#1092 @ 303,207: 24x29\r\n#1093 @ 896,72: 12x28\r\n#1094 @ 704,440: 17x19\r\n#1095 @ 666,157: 14x28\r\n#1096 @ 229,742: 11x14\r\n#1097 @ 964,880: 23x16\r\n#1098 @ 855,20: 29x29\r\n#1099 @ 307,590: 19x13\r\n#1100 @ 79,340: 26x19\r\n#1101 @ 315,591: 11x14\r\n#1102 @ 216,651: 15x13\r\n#1103 @ 575,387: 19x14\r\n#1104 @ 17,416: 19x23\r\n#1105 @ 132,32: 19x23\r\n#1106 @ 146,316: 24x21\r\n#1107 @ 121,131: 18x22\r\n#1108 @ 921,835: 24x13\r\n#1109 @ 233,42: 16x24\r\n#1110 @ 215,80: 22x13\r\n#1111 @ 624,808: 17x15\r\n#1112 @ 805,807: 16x19\r\n#1113 @ 845,195: 13x27\r\n#1114 @ 119,20: 21x20\r\n#1115 @ 596,950: 18x19\r\n#1116 @ 904,203: 26x12\r\n#1117 @ 176,150: 10x28\r\n#1118 @ 436,759: 16x16\r\n#1119 @ 949,388: 29x21\r\n#1120 @ 643,532: 16x24\r\n#1121 @ 279,411: 25x25\r\n#1122 @ 865,141: 11x19\r\n#1123 @ 755,752: 13x25\r\n#1124 @ 189,346: 10x23\r\n#1125 @ 928,599: 17x28\r\n#1126 @ 935,376: 14x25\r\n#1127 @ 68,585: 10x25\r\n#1128 @ 940,553: 21x27\r\n#1129 @ 586,944: 21x24\r\n#1130 @ 216,58: 28x27\r\n#1131 @ 760,390: 26x23\r\n#1132 @ 7,843: 15x11\r\n#1133 @ 772,529: 11x17\r\n#1134 @ 453,774: 10x10\r\n#1135 @ 148,216: 22x18\r\n#1136 @ 481,514: 25x19\r\n#1137 @ 972,755: 20x22\r\n#1138 @ 80,425: 11x6\r\n#1139 @ 641,289: 19x17\r\n#1140 @ 750,412: 10x18\r\n#1141 @ 17,142: 25x11\r\n#1142 @ 434,431: 13x13\r\n#1143 @ 301,602: 11x19\r\n#1144 @ 664,736: 17x23\r\n#1145 @ 152,222: 21x16\r\n#1146 @ 555,234: 22x17\r\n#1147 @ 816,387: 18x13\r\n#1148 @ 783,165: 17x23\r\n#1149 @ 397,681: 12x26\r\n#1150 @ 83,339: 13x15\r\n#1151 @ 402,447: 20x21\r\n#1152 @ 201,95: 10x22\r\n#1153 @ 784,256: 28x10\r\n#1154 @ 58,374: 22x15\r\n#1155 @ 213,472: 14x10\r\n#1156 @ 807,59: 16x23\r\n#1157 @ 126,26: 25x26\r\n#1158 @ 888,493: 13x20\r\n#1159 @ 613,421: 27x15\r\n#1160 @ 361,815: 29x13\r\n#1161 @ 656,175: 10x26\r\n#1162 @ 962,429: 21x18\r\n#1163 @ 884,922: 15x23\r\n#1164 @ 931,179: 14x12\r\n#1165 @ 830,838: 14x18\r\n#1166 @ 154,201: 15x17\r\n#1167 @ 19,962: 27x24\r\n#1168 @ 536,929: 15x10\r\n#1169 @ 225,864: 16x21\r\n#1170 @ 956,390: 22x11\r\n#1171 @ 18,915: 27x25\r\n#1172 @ 153,487: 28x16\r\n#1173 @ 470,261: 23x23\r\n#1174 @ 384,530: 20x17\r\n#1175 @ 218,873: 18x21\r\n#1176 @ 829,416: 25x22\r\n#1177 @ 132,548: 18x20\r\n#1178 @ 106,467: 28x12\r\n#1179 @ 310,418: 23x26\r\n#1180 @ 94,894: 19x11\r\n#1181 @ 607,96: 24x13\r\n#1182 @ 223,74: 12x19\r\n#1183 @ 749,424: 14x15\r\n#1184 @ 626,41: 21x10\r\n#1185 @ 772,769: 28x23\r\n#1186 @ 199,114: 28x29\r\n#1187 @ 519,968: 21x25\r\n#1188 @ 210,727: 10x26\r\n#1189 @ 792,859: 28x24\r\n#1190 @ 658,180: 28x13\r\n#1191 @ 759,250: 20x15\r\n#1192 @ 473,176: 15x10\r\n#1193 @ 565,819: 18x13\r\n#1194 @ 568,842: 21x20\r\n#1195 @ 36,277: 29x21\r\n#1196 @ 46,137: 18x22\r\n#1197 @ 859,248: 16x22\r\n#1198 @ 215,119: 17x17\r\n#1199 @ 475,844: 18x10\r\n#1200 @ 25,888: 24x24\r\n#1201 @ 490,609: 24x29\r\n#1202 @ 890,170: 11x22\r\n#1203 @ 627,320: 26x15\r\n#1204 @ 362,64: 27x21\r\n#1205 @ 790,956: 25x25\r\n#1206 @ 42,783: 10x18\r\n#1207 @ 967,125: 28x19\r\n#1208 @ 938,706: 26x17\r\n#1209 @ 365,888: 5x11\r\n#1210 @ 777,562: 26x24\r\n#1211 @ 166,188: 28x29\r\n#1212 @ 136,492: 27x18\r\n#1213 @ 756,112: 25x12\r\n#1214 @ 121,102: 12x29\r\n#1215 @ 225,704: 27x13\r\n#1216 @ 312,775: 25x10\r\n#1217 @ 413,851: 12x14\r\n#1218 @ 75,579: 28x24\r\n#1219 @ 817,682: 27x12\r\n#1220 @ 212,546: 24x14\r\n#1221 @ 419,207: 24x12\r\n#1222 @ 862,575: 26x26\r\n#1223 @ 611,580: 15x28\r\n#1224 @ 571,607: 28x26\r\n#1225 @ 164,401: 22x25\r\n#1226 @ 143,491: 26x14\r\n#1227 @ 962,565: 19x24\r\n#1228 @ 723,759: 19x24\r\n#1229 @ 787,615: 10x15\r\n#1230 @ 181,943: 28x10\r\n#1231 @ 246,692: 19x25\r\n#1232 @ 947,551: 27x26\r\n#1233 @ 294,57: 18x17\r\n#1234 @ 752,897: 26x20\r\n#1235 @ 745,3: 29x19\r\n#1236 @ 420,613: 19x12\r\n#1237 @ 433,226: 29x12\r\n#1238 @ 966,840: 28x17\r\n#1239 @ 780,434: 10x16\r\n#1240 @ 684,241: 17x23\r\n#1241 @ 357,91: 10x28\r\n#1242 @ 688,75: 20x29\r\n#1243 @ 262,497: 10x25\r\n#1244 @ 88,777: 27x21\r\n#1245 @ 671,977: 22x10\r\n#1246 @ 298,759: 19x24\r\n#1247 @ 663,349: 20x23\r\n#1248 @ 525,109: 23x28\r\n#1249 @ 841,837: 20x20\r\n#1250 @ 147,161: 19x15\r\n#1251 @ 75,161: 26x21\r\n#1252 @ 222,635: 23x28\r\n#1253 @ 839,688: 27x27\r\n#1254 @ 819,295: 20x28\r\n#1255 @ 77,378: 27x23\r\n#1256 @ 38,342: 27x11\r\n#1257 @ 934,46: 14x18\r\n#1258 @ 164,323: 16x19\r\n#1259 @ 198,482: 16x16\r\n#1260 @ 225,713: 26x18\r\n#1261 @ 292,515: 18x18\r\n#1262 @ 915,38: 11x23\r\n#1263 @ 924,121: 15x29\r\n#1264 @ 800,465: 23x15\r\n#1265 @ 215,733: 12x25\r\n#1266 @ 362,354: 23x29\r\n#1267 @ 962,547: 24x25\r\n#1268 @ 477,912: 20x22\r\n#1269 @ 518,3: 23x14\r\n#1270 @ 398,929: 21x29\r\n#1271 @ 603,70: 16x15\r\n#1272 @ 425,212: 25x20\r\n#1273 @ 753,89: 28x25\r\n#1274 @ 910,975: 29x23\r\n#1275 @ 917,113: 21x25\r\n#1276 @ 279,881: 27x27\r\n#1277 @ 84,351: 18x10\r\n#1278 @ 451,26: 13x20\r\n#1279 @ 164,240: 26x14\r\n#1280 @ 578,348: 28x25\r\n#1281 @ 472,795: 15x10\r\n#1282 @ 762,924: 24x12\r\n#1283 @ 524,792: 24x13\r\n#1284 @ 708,892: 22x17\r\n#1285 @ 50,345: 16x11\r\n#1286 @ 446,763: 15x21\r\n#1287 @ 639,794: 22x13\r\n#1288 @ 626,587: 15x14\r\n#1289 @ 54,514: 16x15\r\n#1290 @ 653,39: 16x28\r\n#1291 @ 337,441: 29x21\r\n#1292 @ 499,323: 20x27\r\n#1293 @ 18,42: 25x16\r\n#1294 @ 130,787: 10x14\r\n#1295 @ 801,246: 21x27\r\n#1296 @ 776,628: 19x23\r\n#1297 @ 826,359: 17x13\r\n#1298 @ 666,973: 12x26\r\n#1299 @ 234,662: 29x19\r\n#1300 @ 875,659: 11x11\r\n#1301 @ 607,474: 11x26\r\n#1302 @ 546,858: 10x14\r\n#1303 @ 645,745: 23x18\r\n#1304 @ 387,293: 21x20\r\n#1305 @ 347,692: 28x26\r\n#1306 @ 341,630: 21x13\r\n#1307 @ 604,405: 17x29\r\n#1308 @ 599,576: 20x23\r\n#1309 @ 793,948: 11x29\r\n#1310 @ 167,734: 12x13\r\n#1311 @ 917,167: 16x15\r\n#1312 @ 717,866: 21x14\r\n#1313 @ 617,177: 19x14\r\n#1314 @ 870,325: 14x14\r\n#1315 @ 318,568: 11x26\r\n#1316 @ 396,14: 29x11\r\n#1317 @ 176,934: 20x18\r\n#1318 @ 857,665: 29x15\r\n#1319 @ 849,465: 29x23\r\n#1320 @ 433,128: 20x18\r\n#1321 @ 137,113: 27x22\r\n#1322 @ 333,838: 26x22\r\n#1323 @ 735,64: 15x18\r\n#1324 @ 153,375: 23x24\r\n#1325 @ 416,214: 21x22\r\n#1326 @ 17,122: 17x24\r\n#1327 @ 736,44: 18x12\r\n#1328 @ 14,970: 28x12\r\n#1329 @ 233,342: 17x24\r\n#1330 @ 446,410: 17x24\r\n#1331 @ 308,708: 27x23";
    }
}
